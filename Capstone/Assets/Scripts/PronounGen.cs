using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PronounGen : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputBox;
    [SerializeField] private TMP_InputField removeBox;

    [SerializeField] private TMP_Text pronounDisplayText;
    [SerializeField] private TMP_Text errorDisplayText;

    [SerializeField] private GameObject player;
    private PlayerInfo playerInfo;

    /* References to the objects in playerInfo.cs */
    List<string> playerSubjectPronouns;
    List<string> playerObjectPronouns;
    List<string> playerPossessivePronouns;

    [SerializeField] private GameObject displayLayout;
    [SerializeField] private GameObject singlePronounbox;

    public List<TMP_InputField> multiplierInputBoxes;
    //public List<String> multiplierInputBoxesStr;

    private void Awake()
    {
        playerInfo = player.GetComponent<PlayerInfo>();
        multiplierInputBoxes = new List<TMP_InputField>();
        //multiplierInputBoxesStr = new List<String>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ClearPronouns();
    }

    public void AddNewPronoun() {
        string toAdd = inputBox.text;
        toAdd = toAdd.ToLower();
        toAdd = toAdd.Replace(" ", "");

        string[] split = toAdd.Split("/");
        bool err = false;

        if (split.Length != 3) {
             err = true;
        }

        for (int i = 0; i < split.Length; i++) {
            if (split[i].Length == 0) { 
                err = true;
                break;
            }
        }

        if (!err) {
            if (AlreadyContainsPronoun(split))
                errorDisplayText.text = toAdd + " is already in your pronoun list";
            else {
                playerSubjectPronouns.Add(split[0]);
                playerObjectPronouns.Add(split[1]);
                playerPossessivePronouns.Add(split[2]);

                GameObject disp = Instantiate(singlePronounbox, Vector3.zero, Quaternion.identity, displayLayout.gameObject.transform);
                disp.GetComponent<TextMeshProUGUI>().text = toAdd;
                multiplierInputBoxes.Add(disp.GetComponentInChildren<TMP_InputField>());
                //multiplierInputBoxesStr.Add(disp.GetComponentInChildren<Transform>().GetComponentInChildren<Transform>().GetComponentInChildren<TextMeshProUGUI>().text);
                //No
                playerInfo.numPronouns++;
                errorDisplayText.text = "";
            
                UpdateDisplayText();
            }

            inputBox.text = "";
            inputBox.Select();
        }
        else
            errorDisplayText.text = "Pronouns must adhear to the above format";

    }

    //Pre-condition: split.Length = 3
    private bool AlreadyContainsPronoun(string[] split) {
        for (int i = 0; i < playerInfo.numPronouns; i++) {
            if (playerSubjectPronouns[i] == split[0] && playerObjectPronouns[i] == split[1] && playerPossessivePronouns[i] == split[2])
                return true;
        }

        return false;
    }

    public void RemovePronoun() {
        string toRemove = removeBox.text;
        bool itemWasRemoved = false;


        for (int i = 0; i < playerInfo.numPronouns; i++)
        {
            string currentPronoun = playerSubjectPronouns[i] + "/" + playerObjectPronouns[i] + "/" + playerPossessivePronouns[i];
            currentPronoun = currentPronoun.ToLower();

            if (toRemove.ToLower().Equals(currentPronoun)) {
                playerSubjectPronouns.Remove(playerSubjectPronouns[i]);
                playerObjectPronouns.Remove(playerObjectPronouns[i]);
                playerPossessivePronouns.Remove(playerPossessivePronouns[i]);

                multiplierInputBoxes.RemoveAt(i);

                playerInfo.numPronouns--;
                itemWasRemoved = true;
                break;
            }
        }

        if (!itemWasRemoved)
            errorDisplayText.text = "\"" + toRemove + "\" was not in your pronoun list";
        else
            errorDisplayText.text = "";

        removeBox.text = "";
        removeBox.Select();

        UpdateDisplayText();
    }

    public void ClearPronouns() {
        playerInfo.InitializeNewPronounLists();
        playerSubjectPronouns = playerInfo.playerSubjectPronouns;
        playerObjectPronouns = playerInfo.playerObjectPronouns;
        playerPossessivePronouns = playerInfo.playerPossessivePronouns;
        UpdateDisplayText();
    }

    public void UpdateDisplayText() {
        pronounDisplayText.text = playerInfo.playerName + "'s pronouns:";
        for (int i = 0; i < playerInfo.numPronouns; i++)
        {
            pronounDisplayText.text += "\n- " + playerSubjectPronouns[i] + "/" + playerObjectPronouns[i] + "/" + playerPossessivePronouns[i];
        }
    }
}

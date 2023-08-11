using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    private int numPronouns;

    private void Awake()
    {
        playerInfo = player.GetComponent<PlayerInfo>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ClearPronouns();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            {
                errorDisplayText.text = toAdd + " is already in your pronoun list";

            }
            else {             
                playerSubjectPronouns.Add(split[0]);
                playerObjectPronouns.Add(split[1]);
                playerPossessivePronouns.Add(split[2]);

                numPronouns++;
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
        for (int i = 0; i < numPronouns; i++) {
            if (playerSubjectPronouns[i] == split[0] && playerObjectPronouns[i] == split[1] && playerPossessivePronouns[i] == split[2])
                return true;
        }

        return false;
    }

    public void RemovePronoun() {
        string toRemove = removeBox.text;
        bool itemWasRemoved = false;


        for (int i = 0; i < numPronouns; i++)
        {
            string currentPronoun = playerSubjectPronouns[i] + "/" + playerObjectPronouns[i] + "/" + playerPossessivePronouns[i];
            currentPronoun = currentPronoun.ToLower();

            if (toRemove.ToLower().Equals(currentPronoun)) {
                playerSubjectPronouns.Remove(playerSubjectPronouns[i]);
                playerObjectPronouns.Remove(playerObjectPronouns[i]);
                playerPossessivePronouns.Remove(playerPossessivePronouns[i]);

                numPronouns--;
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
        numPronouns = 0;
        UpdateDisplayText();
    }

    private void UpdateDisplayText() {
        pronounDisplayText.text = "Your Character's Pronouns:";
        for (int i = 0; i < numPronouns; i++)
        {
            pronounDisplayText.text += "\n- " + playerSubjectPronouns[i] + "/" + playerObjectPronouns[i] + "/" + playerPossessivePronouns[i];
        }
    }
}

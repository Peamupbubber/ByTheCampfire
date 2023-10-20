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

    [SerializeField] private GameObject displayLayout;
    [SerializeField] private GameObject singlePronounbox;

    [SerializeField] private List<GameObject> pronounDisplays;

    private void Awake()
    {
        playerInfo = player.GetComponent<PlayerInfo>();
        pronounDisplays = new List<GameObject>();
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

        if (!err) { 
            for (int i = 0; i < split.Length; i++) {
                if (split[i].Length == 0) { 
                    err = true;
                    break;
                }
            }
        }

        if (!err) {
            if (AlreadyContainsPronoun(split))
                errorDisplayText.text = toAdd + " is already in your pronoun list";
            else {
                playerInfo.pronouns.Add(split);

                pronounDisplays.Add(Instantiate(singlePronounbox, Vector3.zero, Quaternion.identity, displayLayout.gameObject.transform));
                pronounDisplays[playerInfo.numPronouns].GetComponent<TextMeshProUGUI>().text = toAdd;
                playerInfo.numPronouns++;
                errorDisplayText.text = "";
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
            if (playerInfo.pronouns[i][0] == split[0] && playerInfo.pronouns[i][1] == split[1] && playerInfo.pronouns[i][2] == split[2])
                return true;
        }

        return false;
    }

    public void RemovePronoun() {
        string toRemove = removeBox.text;
        bool itemWasRemoved = false;


        for (int i = 0; i < playerInfo.numPronouns; i++)
        {
            string currentPronoun = playerInfo.pronouns[i][0] + "/" + playerInfo.pronouns[i][1] + "/" + playerInfo.pronouns[i][2];
            currentPronoun = currentPronoun.ToLower();

            if (toRemove.ToLower().Equals(currentPronoun)) {
                playerInfo.pronouns.RemoveAt(i);

                RemovePronounDisplay(i);

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
    }

    public void ClearPronouns() {
        playerInfo.InitializeNewPronounLists();

        while (pronounDisplays.Count > 0) {
            RemovePronounDisplay(0);
        }
    }

    private void RemovePronounDisplay(int i) {
        GameObject dispToRemove = pronounDisplays[i];
        pronounDisplays.RemoveAt(i);
        Destroy(dispToRemove);
    }

    public void UpdateDisplayText() {
        pronounDisplayText.text = playerInfo.playerName + "'s pronouns:";
    }

    //This might not be the best way, recreating the list every time
    public void UpdateMultipliers() {
        playerInfo.multipliers = new List<int>();
        for (int i = 0; i < playerInfo.numPronouns; i++) {
            playerInfo.multipliers.Add(pronounDisplays[i].GetComponent<PronounDisplay>().multiplier);
        }
    }
}

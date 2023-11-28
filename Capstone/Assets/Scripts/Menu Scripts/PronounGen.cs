using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PronounGen : MonoBehaviour
{
    [SerializeField] private TMP_InputField subjInputField;
    [SerializeField] private TMP_InputField objInputField;
    [SerializeField] private TMP_InputField possInputField;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Slash)) {
            if (subjInputField.isFocused) {
                if (Input.GetKeyDown(KeyCode.Slash)) subjInputField.text = subjInputField.text.Substring(0, subjInputField.text.Length - 1);
                objInputField.Select();
            }
            else if (objInputField.isFocused) {
                if (Input.GetKeyDown(KeyCode.Slash)) objInputField.text = objInputField.text.Substring(0, objInputField.text.Length - 1);
                possInputField.Select();
            }
            else if (possInputField.isFocused) {
                if (Input.GetKeyDown(KeyCode.Slash)) possInputField.text = possInputField.text.Substring(0, possInputField.text.Length - 1);
                subjInputField.Select();
            }
            else
                subjInputField.Select();
        }
        else if (Input.GetKeyDown(KeyCode.Return)) {
            AddNewPronoun();
        }
    }

    public void AddNewPronoun() {
        string[] pronouns = new string[3];
        string toDisplay;

        pronouns[0] = subjInputField.text.ToLower();
        pronouns[1] = objInputField.text.ToLower();
        pronouns[2] = possInputField.text.ToLower();
        toDisplay = pronouns[0] + "/" + pronouns[1] + "/" + pronouns[2];

        if (pronouns[0] == "" || pronouns[1] == "" || pronouns[2] == "") {
            errorDisplayText.text = "All three pronoun types must be filled";
        }
        else {
            playerInfo.pronouns.Add(pronouns);

            pronounDisplays.Add(Instantiate(singlePronounbox, Vector3.zero, Quaternion.identity, displayLayout.gameObject.transform));
            pronounDisplays[playerInfo.numPronouns].GetComponent<TextMeshProUGUI>().text = toDisplay;
            pronounDisplays[playerInfo.numPronouns].GetComponentInChildren<Button>().onClick.AddListener(RemovePronoun);
            pronounDisplays[playerInfo.numPronouns].GetComponentInChildren<PronounDisplay>().playerInfo = playerInfo;

            playerInfo.pronounsChanged = true;
            playerInfo.numPronouns++;
            errorDisplayText.text = "";

            subjInputField.text = "";
            objInputField.text = "";
            possInputField.text = "";
            subjInputField.Select();
        }
    }

    public void RemovePronoun() {
        for (int i = 0; i < playerInfo.numPronouns; i++) {
            if (pronounDisplays[i].GetComponent<PronounDisplay>().removeClicked) {
                string toRemove = pronounDisplays[i].GetComponent<TextMeshProUGUI>().text;

                playerInfo.pronouns.RemoveAt(i);

                RemovePronounDisplay(i);

                playerInfo.pronounsChanged = true;
                playerInfo.numPronouns--;
                break;
            }
        }
    }

    /* Might come in useful if I want to require not adding the same one
    //Pre-condition: split.Length = 3
    private bool AlreadyContainsPronoun(string[] split)
    {
        for (int i = 0; i < playerInfo.numPronouns; i++)
        {
            if (playerInfo.pronouns[i][0] == split[0] && playerInfo.pronouns[i][1] == split[1] && playerInfo.pronouns[i][2] == split[2])
                return true;
        }

        return false;
    } */

    public void ClearPronouns() {
        playerInfo.InitializeNewPronounLists();
        playerInfo.pronounsChanged = true;

        while (pronounDisplays.Count > 0) {
            RemovePronounDisplay(0);
        }

        subjInputField.text = "";
        objInputField.text = "";
        possInputField.text = "";
        subjInputField.Select();
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

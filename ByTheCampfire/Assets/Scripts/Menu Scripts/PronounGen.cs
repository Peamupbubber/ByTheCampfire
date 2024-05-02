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

    [SerializeField] private Character characterInfo;

    [SerializeField] private GameObject displayLayout;
    [SerializeField] private GameObject singlePronounbox;

    [SerializeField] private List<GameObject> pronounDisplays = new List<GameObject>();

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
            characterInfo.pronouns.Add(pronouns);

            pronounDisplays.Add(Instantiate(singlePronounbox, Vector3.zero, Quaternion.identity, displayLayout.gameObject.transform));
            pronounDisplays[characterInfo.numPronouns].GetComponent<TextMeshProUGUI>().text = toDisplay;
            pronounDisplays[characterInfo.numPronouns].GetComponentInChildren<Button>().onClick.AddListener(RemovePronoun);
            pronounDisplays[characterInfo.numPronouns].GetComponentInChildren<PronounDisplay>().characterInfo = characterInfo;

            characterInfo.pronounsChanged = true;
            characterInfo.numPronouns++;
            errorDisplayText.text = "";

            subjInputField.text = "";
            objInputField.text = "";
            possInputField.text = "";
            subjInputField.Select();
        }
    }

    //Used for initializing the NPC default pronouns
    public void AddNewPronoun(string[] pronouns) {
        string toDisplay = pronouns[0] + "/" + pronouns[1] + "/" + pronouns[2];

        characterInfo.pronouns.Add(pronouns);

        pronounDisplays.Add(Instantiate(singlePronounbox, Vector3.zero, Quaternion.identity, displayLayout.gameObject.transform));
        pronounDisplays[characterInfo.numPronouns].GetComponent<TextMeshProUGUI>().text = toDisplay;
        pronounDisplays[characterInfo.numPronouns].GetComponentInChildren<Button>().onClick.AddListener(RemovePronoun);
        pronounDisplays[characterInfo.numPronouns].GetComponentInChildren<PronounDisplay>().characterInfo = characterInfo;

        characterInfo.pronounsChanged = true;
        characterInfo.numPronouns++;
    }

    public void RemovePronoun() {
        for (int i = 0; i < characterInfo.numPronouns; i++) {
            if (pronounDisplays[i].GetComponent<PronounDisplay>().removeClicked) {
                string toRemove = pronounDisplays[i].GetComponent<TextMeshProUGUI>().text;

                characterInfo.pronouns.RemoveAt(i);

                RemovePronounDisplay(i);

                characterInfo.pronounsChanged = true;
                characterInfo.numPronouns--;
                break;
            }
        }
    }

    public void ClearPronouns() {
        characterInfo.InitializeNewPronounLists();
        characterInfo.pronounsChanged = true;

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

    //This might not be the best way, recreating the list every time
    //Called by the Start Game button
    public void UpdateMultipliers() {
        characterInfo.multipliers = new List<int>();
        for (int i = 0; i < characterInfo.numPronouns; i++) {
            characterInfo.multipliers.Add(pronounDisplays[i].GetComponent<PronounDisplay>().multiplier);
        }
    }
}

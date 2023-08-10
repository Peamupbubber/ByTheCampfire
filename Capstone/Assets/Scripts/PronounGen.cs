using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Unity.VisualScripting;

public class PronounGen : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputBox;
    [SerializeField] private TMP_InputField removeBox;

    [SerializeField] private TMP_Text pronounDisplayText;
    [SerializeField] private TMP_Text errorDisplayText;


    /* Consider migrating pronoun info to txt files where I can store player data for saves */
    List<string> playerSubjectPronouns = new List<string>();
    List<string> playerObjectPronouns = new List<string>();
    List<string> playerPossessivePronouns = new List<string>();

    private int numPronouns = 0;

    // Start is called before the first frame update
    void Start()
    {

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
            if (alreadyContainsPronoun(split))
            {
                errorDisplayText.text = toAdd + " is already in your pronoun list";

            }
            else {             
                playerSubjectPronouns.Add(split[0]);
                playerObjectPronouns.Add(split[1]);
                playerPossessivePronouns.Add(split[2]);

                numPronouns++;
                errorDisplayText.text = "";     
            
                updateDisplayText();
            }

            inputBox.text = "";
            inputBox.Select();
        }
        else
            errorDisplayText.text = "Pronouns must adhear to the above format";

    }

    //Pre-condition: split.Length = 3
    private bool alreadyContainsPronoun(string[] split) {
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
            errorDisplayText.text = "\"" + toRemove + "\" was not removed as it was not in the list";
        else
            errorDisplayText.text = "";

        removeBox.text = "";
        removeBox.Select();

        updateDisplayText();
    }

    private void updateDisplayText() {
        pronounDisplayText.text = "Your Character's Pronouns:";
        for (int i = 0; i < numPronouns; i++)
        {
            pronounDisplayText.text += "\n- " + playerSubjectPronouns[i] + "/" + playerObjectPronouns[i] + "/" + playerPossessivePronouns[i];
        }
    }
}

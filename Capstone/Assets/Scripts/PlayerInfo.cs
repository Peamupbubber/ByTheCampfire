using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{

    public string playerName;

    public List<string> playerSubjectPronouns;
    public List<string> playerObjectPronouns;
    public List<string> playerPossessivePronouns;
    public int numPronouns;

    [SerializeField] private TMP_InputField playerNameInputField;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void InitializeNewPronounLists() {
        playerSubjectPronouns = new List<string>();
        playerObjectPronouns = new List<string>();
        playerPossessivePronouns = new List<string>();
        numPronouns = 0;
    }

    public void UpdatePlayerName() {
        playerName = playerNameInputField.text;
    }

    /* Change these to get a random pronoun */
    public string GetASubjectPronoun() {
        int numPronouns = playerSubjectPronouns.Count;
        string pronoun = name;

        if (numPronouns != 0) {
            pronoun = playerSubjectPronouns[Random.Range(0, numPronouns)];
        }

        return pronoun;
    }

    public string GetAnObjectPronoun()
    {
        int numPronouns = playerObjectPronouns.Count;
        string pronoun = name;

        if (numPronouns != 0)
        {
            pronoun = playerObjectPronouns[Random.Range(0, numPronouns)];
        }

        return pronoun;
    }

    public string GetAPossessivePronoun()
    {
        int numPronouns = playerPossessivePronouns.Count;
        string pronoun = name;

        if (numPronouns != 0)
        {
            pronoun = playerPossessivePronouns[Random.Range(0, numPronouns)];
        }

        return pronoun;
    }
}

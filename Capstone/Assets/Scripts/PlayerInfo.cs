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

    [SerializeField] private List<string> playerSPCapital;
    [SerializeField] private List<string> playerOPCapital;
    [SerializeField] private List<string> playerPPCapital;

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

    /* set the capital lists equal to the pronoun lists but with the first letter capitalized */
    public void UpdateCaptalLists() {
        playerSPCapital = new List<string>();
        playerOPCapital = new List<string>();
        playerPPCapital = new List<string>();
        string s;

        for (int i = 0; i < numPronouns; i++) {
            s = playerSubjectPronouns[i].ToUpper()[0] + playerSubjectPronouns[i].Substring(1);
            playerSPCapital.Add(s);

            s = playerObjectPronouns[i].ToUpper()[0] + playerObjectPronouns[i].Substring(1);
            playerOPCapital.Add(s);

            s = playerPossessivePronouns[i].ToUpper()[0] + playerPossessivePronouns[i].Substring(1);
            playerPPCapital.Add(s);
        }
    }

    public string GetASubjectPronoun(bool cap) {
        string pronoun = name;

        if (numPronouns != 0) {
            List<string> l = cap ? playerSPCapital : playerSubjectPronouns;
            pronoun = l[Random.Range(0, numPronouns)];
        }

        return pronoun;
    }

    public string GetAnObjectPronoun(bool cap)
    {
        string pronoun = name;

        if (numPronouns != 0) {

            List<string> l = cap ? playerOPCapital : playerObjectPronouns;
            pronoun = l[Random.Range(0, numPronouns)];
        }

        return pronoun;
    }

    public string GetAPossessivePronoun(bool cap)
    {
        string pronoun = name;

        if (numPronouns != 0)
        {
            List<string> l = cap ? playerPPCapital : playerPossessivePronouns;
            pronoun = l[Random.Range(0, numPronouns)];
        }

        return pronoun;
    }
}

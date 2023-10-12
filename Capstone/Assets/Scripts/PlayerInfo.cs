using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameInputField;

    public List<string> playerSubjectPronouns;
    public List<string> playerObjectPronouns;
    public List<string> playerPossessivePronouns;

    //don't need to be SF at the end
    [SerializeField] private List<string> playerSPCapital;
    [SerializeField] private List<string> playerOPCapital;
    [SerializeField] private List<string> playerPPCapital;


    public string playerName;
    public int numPronouns;
    private int lastPronounIndex;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void InitializeNewPronounLists() {
        playerSubjectPronouns = new List<string>();
        playerObjectPronouns = new List<string>();
        playerPossessivePronouns = new List<string>();
        numPronouns = 0;
        lastPronounIndex = -1;
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
        string pronoun = playerName;

        if (numPronouns != 0) {
            List<string> l = cap ? playerSPCapital : playerSubjectPronouns;
            pronoun = l[GetPronounIndex()];
        }

        return pronoun;
    }

    public string GetAnObjectPronoun(bool cap)
    {
        string pronoun = playerName;

        if (numPronouns != 0) {

            List<string> l = cap ? playerOPCapital : playerObjectPronouns;
            pronoun = l[GetPronounIndex()];
        }

        return pronoun;
    }

    public string GetAPossessivePronoun(bool cap)
    {
        string pronoun = playerName;

        if (numPronouns != 0)
        {
            List<string> l = cap ? playerPPCapital : playerPossessivePronouns;
            pronoun = l[GetPronounIndex()];
        }

        return pronoun;
    }

    private int GetPronounIndex()
    {
        int endRange = lastPronounIndex == -1 ? numPronouns : numPronouns - 1;
        int r = Random.Range(0, endRange);
        r = r == lastPronounIndex ? numPronouns - 1 : r;
        lastPronounIndex = r;
        return r;
    }
}

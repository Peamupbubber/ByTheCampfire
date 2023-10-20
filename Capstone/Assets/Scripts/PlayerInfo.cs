using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = System.Random;

public class PlayerInfo : MonoBehaviour
{
    public enum pronoun_type { SUBJECT, OBJECT, POSSESSIVE};

    private Random rng = new Random();
    private TMP_InputField playerNameInputField;

    [HideInInspector] public List<string[]> pronouns;

    /* [HideInInspector] */ public List<int> pronounQueue;
    /* [HideInInspector] */ public List<int> multipliers;

    public string playerName;
    public int numPronouns;

    private void Awake()
    {
        playerNameInputField = GameObject.Find("PlayerNameInputField").GetComponent<TMP_InputField>();
        gameObject.SetActive(false);
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        pronounQueue = new List<int>();
    }

    private void CreatePronounQueue() {
        for (int i = 0; i < numPronouns; i++) {
            for (int j = 0; j < multipliers[i]; j++) {
                pronounQueue.Add(i);
            }
        }

        ShuffleQueue();
    }

    /* https://stackoverflow.com/questions/273313/randomize-a-listt */
    private void ShuffleQueue() {
        int n = pronounQueue.Count;
        while (n > 1) {
            n--;
            int k = rng.Next(n + 1);
            int v = pronounQueue[k];
            pronounQueue[k] = pronounQueue[n];
            pronounQueue[n] = v;
        }
    }

    public void PrintPronouns() {
        for (int i = 0; i < numPronouns; i++) {
            Debug.Log(pronouns[i][0] + ", " + pronouns[i][1] + ", " + pronouns[i][2]);
        }
    }

    public void InitializeNewPronounLists() {
        numPronouns = 0;
        multipliers = new List<int>();
        pronouns = new List<string[]>();
    }

    public void UpdatePlayerName() {
        playerName = playerNameInputField.text;
        if(playerName.Length > 0) playerName = playerName.ToUpper()[0] + playerName.Substring(1);
    }

    public string GetAPronoun(pronoun_type type, bool cap) {
        string pronoun = playerName;
        if (numPronouns > 0) {
            pronoun = pronouns[GetPronounIndex()][(int)type];
            if (cap) pronoun = pronoun.ToUpper()[0] + pronoun.Substring(1);
        }

        return pronoun;
    }

    //Returns a pronoun followed by a present tense verb ('is' or 'are' depending on the pronoun)
    public string GetAPronounAndPTV(pronoun_type type, bool cap) {
        string pronoun = GetAPronoun(type, cap);
        string ptv = pronoun.Equals("they") ? "are" : "is";

        return pronoun + " " + ptv;
    }

    public string GetAPossessivePronounWithS() {
        string pronoun = GetAPronoun(pronoun_type.POSSESSIVE, false);

        if (pronoun[pronoun.Length - 1] != 's')
            pronoun += 's';

        return pronoun;
    }

    private int GetPronounIndex()
    {
        if (pronounQueue.Count == 0)
            CreatePronounQueue();

        int r = pronounQueue[0];
        pronounQueue.RemoveAt(0);

        return r;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static GameManager;
using Random = System.Random;

[RequireComponent(typeof(PronounProcessor))]

public class PlayerInfo : MonoBehaviour, Character
{
    private Random rng = new Random();

    [HideInInspector] public List<string[]> pronouns;

    /* [HideInInspector] */ public List<int> pronounQueue;
    /* [HideInInspector] */ public List<int> multipliers;

    public string playerName;
    public int numPronouns;

    public bool pronounsChanged = false;

    [HideInInspector] public bool canMove = true;
    [HideInInspector] public bool paused = true;

    [HideInInspector] public PronounProcessor pronounProcessor;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        pronounQueue = new List<int>();
        pronounProcessor = GetComponent<PronounProcessor>();
    }

    public void CreatePronounQueue() {
        //Remake the queue incase it's being called from MenuManager
        if (pronounsChanged) { 
            pronounQueue = new List<int>();
            pronounsChanged = false;
        }

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

    public void UpdatePlayerName(string name) {
        if(name.Length > 0) name = name.ToUpper()[0] + name.Substring(1);
        playerName = name;
    }

    public string GetPronoun(pronoun_type type, bool cap) {
        string pronoun = playerName;
        if (numPronouns > 0) {
            pronoun = pronouns[GetPronounIndex()][(int)type];
            if (cap) pronoun = pronoun.ToUpper()[0] + pronoun.Substring(1);
        }

        return pronoun;
    }

    /* Functions to assist grammatical accuracy, this may not always work with neopronouns that do not follow traditional english grammar

    //Returns a pronoun followed by a present tense verb ('is' or 'are' depending on the pronoun)
    public string GetAPronounAndToBeVerb(pronoun_type type, bool cap) {
        string pronoun = GetPronoun(type, cap);
        string v = pronoun.Equals("they") ? "are" : "is";

        return pronoun + " " + v;
    }

    public string GetAPronounAndToHaveVerb(pronoun_type type, bool cap)
    {
        string pronoun = GetPronoun(type, cap);
        string v = pronoun.Equals("they") ? "have" : "has";

        return pronoun + " " + v;
    }

    //If the pronoun is 'they', the following verb does not include an 's', otherwise it does
    //e.g. They own X, He owns X
    //Usage: func(SUBJECT, false, "own") --> they own | he owns | ...
    public string GetAPronounPlusFollowingVerb(pronoun_type type, bool cap, string folowing)
    {
        string pronoun = GetPronoun(type, cap);
        string s = pronoun.Equals("they") ? "" : "s";

        return pronoun + " " + folowing + s;
    }

    public string GetAPossessivePronounWithS() {
        string pronoun = GetPronoun(pronoun_type.POSSESSIVE, false);

        if (pronoun[pronoun.Length - 1] != 's')
            pronoun += 's';

        return pronoun;
    }

    **************************************************************************************************************************************/

    private int GetPronounIndex()
    {
        if (pronounQueue.Count == 0)
            CreatePronounQueue();

        int r = pronounQueue[0];
        pronounQueue.RemoveAt(0);

        return r;
    }

    public void Pronounschanged() {
        pronounsChanged = true;
    }

    public void PausePressed()
    {
        paused = !paused;
    }
}

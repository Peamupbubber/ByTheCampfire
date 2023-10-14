using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = System.Random;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameInputField;

    //These can be HideInInspector
    public List<string[]> pronouns;
    public List<int> pronounQueue;

    public List<int> multipliers;

    public enum pronoun_type { SUBJECT, OBJECT, POSSESSIVE};

    private Random rng = new Random();

    public string playerName;
    public int numPronouns;

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
    }

    public string GetAPronoun(pronoun_type type, bool cap) {
        string pronoun = playerName;
        if (numPronouns > 0) {
            pronoun = pronouns[GetPronounIndex()][(int)type];
            if (cap) pronoun = pronoun.ToUpper()[0] + pronoun.Substring(1);
        }

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

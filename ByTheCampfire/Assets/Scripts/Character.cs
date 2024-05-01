using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public int numPronouns;
    public bool pronounsChanged = false;
    /* [HideInInspector] */ public List<string[]> pronouns;
    /* [HideInInspector] */ public List<int> multipliers;

    [SerializeField] protected PronounGen pronounGen;

    //Moved from playerInfo
    public void InitializeNewPronounLists()
    {
        numPronouns = 0;
        multipliers = new List<int>();
        pronouns = new List<string[]>();
    }

    //For Debugging
    public void PrintPronouns()
    {
        for (int i = 0; i < numPronouns; i++)
        {
            Debug.Log(pronouns[i][0] + ", " + pronouns[i][1] + ", " + pronouns[i][2]);
        }
    }
}

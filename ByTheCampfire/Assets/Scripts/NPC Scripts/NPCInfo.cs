using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = System.Random;

public class NPCInfo : Character
{
    private readonly Random rng = new();

    private void Awake()
    {
        InitializeNewPronounLists();
        InitializeNPCPronounOptions();
    }

    public void InitializeNPCPronounOptions()
    {
        string path = Application.dataPath + "/StreamingAssets/npc_pronoun_options.txt";

        StreamReader reader = new StreamReader(path);

        string nextLine = reader.ReadLine();
        while (nextLine != null)
        {
            //Add each default pronoun to the display (also adds the entry to the set of pronouns)
            pronounGen.AddNewPronoun(nextLine.Split(" "));

            multipliers.Add(1);

            nextLine = reader.ReadLine();
        }

        reader.Close();
    }

    //Generates a random set of pronouns for an NPC. Tends to get around 3 option but can be more or less. Assigns a random weight up to 10 for each one
    //Always adds it once when it's chosen, assigns it up to 9 more times
    public List<string[]> GetNPCPronounSet()
    {
        List<string[]> set = new List<string[]>();

        for (int i = 0; i < numPronouns; i++)
        {
            if (rng.Next(numPronouns + 2) / numPronouns == 1)
            {
                set.Add(pronouns[i]);
                for (int j = 0; j < rng.Next(9); j++)
                {
                    set.Add(pronouns[i]);
                }
            }
        }

        return set;
    }
}

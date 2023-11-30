using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class PronounProcessor : MonoBehaviour
{
    private Character character;

    private void Start()
    {
        character = GetComponent<Character>();
    }

    /* Functions to assist grammatical accuracy, this may not always work with neopronouns that do not follow traditional english grammar */

    //Returns a pronoun followed by a present tense verb ('is' or 'are' depending on the pronoun)
    public string GetAPronounAndToBeVerb(pronoun_type type, bool cap)
    {
        string pronoun = character.GetPronoun(type, cap);
        string v = pronoun.Equals("they") ? "are" : "is";

        return pronoun + " " + v;
    }

    public string GetAPronounAndToHaveVerb(pronoun_type type, bool cap)
    {
        string pronoun = character.GetPronoun(type, cap);
        string v = pronoun.Equals("they") ? "have" : "has";

        return pronoun + " " + v;
    }

    //If the pronoun is 'they', the following verb does not include an 's', otherwise it does
    //e.g. They own X, He owns X
    //Usage: func(SUBJECT, false, "own") --> they own | he owns | ...
    public string GetAPronounPlusFollowingVerb(pronoun_type type, bool cap, string folowing)
    {
        string pronoun = character.GetPronoun(type, cap);
        string s = pronoun.Equals("they") ? "" : "s";

        return pronoun + " " + folowing + s;
    }

    public string GetAPossessivePronounWithS()
    {
        string pronoun = character.GetPronoun(pronoun_type.POSSESSIVE, false);

        if (pronoun[pronoun.Length - 1] != 's')
            pronoun += 's';

        return pronoun;
    }

    /**************************************************************************************************************************************/

}

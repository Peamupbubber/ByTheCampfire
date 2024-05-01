using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class PronounProcessor : MonoBehaviour
{
    private CharacterInterface character;

    private void Start()
    {
        character = GetComponent<CharacterInterface>();
    }

    /* Functions to assist grammatical accuracy, this may not always work with neopronouns that do not follow traditional english grammar */

    //'To be', 'to have', and other following verbs differ for subject pronoun 'they'
    public string GetASubjectAndToBeVerb(bool cap)
    {
        string pronoun = character.GetPronoun(pronoun_type.SUBJECT, cap);
        string v = pronoun.ToLower().Equals("they") ? "are" : "is";

        return pronoun + " " + v;
    }

    public string GetASubjectAndToHaveVerb(bool cap)
    {
        string pronoun = character.GetPronoun(pronoun_type.SUBJECT, cap);
        string v = pronoun.ToLower().Equals("they") ? "have" : "has";

        return pronoun + " " + v;
    }

    //If the pronoun is 'they', the following verb does not include an 's', otherwise it does
    //e.g. They own X, He owns X
    //Usage: func(false, "own") --> they own | he owns | ...
    public string GetASubjectPlusFollowingVerb(bool cap, string folowing)
    {
        string pronoun = character.GetPronoun(pronoun_type.SUBJECT, cap);
        string s = pronoun.ToLower().Equals("they") ? "" : "s";

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

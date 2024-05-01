using System.Collections.Generic;
using UnityEngine;
using static GameManager;

/* Implemented by playerInfo and NPC. Forces them to have a GetPronoun method but implementation is different.
 * Allows Pronoun Processor to use it regardless of what it is attatched to.
 * 
 * All Characters should have associated name (string) and pronoun (List<string[]>) fields
 */

public interface CharacterInterface
{

    //Should be implemented such that a random pronoun is returned or the character's name if the character has no pronouns associated
    public string GetPronoun(pronoun_type type, bool cap);
}

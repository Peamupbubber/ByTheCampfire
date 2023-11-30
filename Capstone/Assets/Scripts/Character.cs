using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

/* Implemented by playerInfo and NPC. Forces them to have a GetPronoun method but implementation is different.
 * Allows Pronoun Processor to use it regardless of what it is attatched to.
 */

public interface Character
{
    public string GetPronoun(pronoun_type type, bool cap);
}

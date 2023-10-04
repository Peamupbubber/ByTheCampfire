using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : Interactable
{
    private IEnumerator Interacted() {
        StartInteraction();

        NewDialogueOutput("It's a crate...");

        while (!DialogueSkipped()) yield return null;

        EndInteraction();
    }

    protected override void HandleCurrentInteraction()
    {
        StartCoroutine(Interacted());
    }
}

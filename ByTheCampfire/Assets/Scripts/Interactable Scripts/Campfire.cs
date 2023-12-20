using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : Interactable
{
    private IEnumerator Interacted()
    {
        StartInteraction();

        NewDialogueOutput("The warmth of the fire is comforting");

        while (!DialogueSkipped()) { yield return null; }

        EndInteraction();
    }

    protected override void HandleCurrentInteraction()
    {
        StartCoroutine(Interacted());
    }
}

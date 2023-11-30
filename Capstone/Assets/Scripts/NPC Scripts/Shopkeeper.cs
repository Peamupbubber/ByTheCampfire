using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static GameManager;

public class Shopkeeper : NPC
{
    protected override void HandleCurrentInteraction()
    {
        StartCoroutine(FirstInteraction());
    }

    private IEnumerator FirstInteraction()
    {
        StartInteractionWithResponse();

        NewDialogueOutput("You’re " + playerInfo.playerName + " right? Nice to meet you! I’m "+ npcName + ". I run the shop here. If you ever need any supplies or tools come right to me!");
        gameManager.SetResponseButtonText1("Nice to meet you!");
        gameManager.SetResponseButtonText2("What do you have for sale?");
        gameManager.SetResponseButtonText3("Nothing for now, thanks.");

        /* Wait for a response from the player */
        while (!PlayerResponded()) { yield return null; }

        switch (response)
        {
            case Response.R1:
                NewDialogueOutput("Good to meet you too! You know, ...");

                break;

            case Response.R2:
                NewDialogueOutput("Just a few things I’ve collected in our short time here");

                //Show shop!

                break;

            case Response.R3:
                NewDialogueOutput("Hope to see you again!");

                break;
        }
        
        while (!DialogueSkipped()) { yield return null; }

        ClearResponse();

        EndInteractionWithResponse();
    }
}

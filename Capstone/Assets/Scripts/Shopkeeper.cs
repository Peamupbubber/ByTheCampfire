using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shopkeeper : NPC
{
    // Start is called before the first frame update
    void Start()
    {
        response = GameManager.Response.None;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // This is how interactions between the player and an NPC will be represented
    private IEnumerator Interaction()
    {
        StartInteractionWithResponse();

        NewDialogueOutput("You’re " + playerInfo.playerName + " right? Nice to meet you! I’m Charlotte. I run the shop here. If you ever need any supplies or tools come right to me!");
        gameManager.SetResponseButtonText1("Nice to meet you!");
        gameManager.SetResponseButtonText2("What do you have for sale?");
        gameManager.SetResponseButtonText3("Nothing for now, thanks.");

        /* Wait for a response from the player */
        while (!PlayerResponded()) { yield return null; }

        switch (response)
        {
            case GameManager.Response.R1:
                NewDialogueOutput("Good to meet you too! You know, ...");

                while (!DialogueSkipped()) { yield return null; }

                break;

            case GameManager.Response.R2:
                NewDialogueOutput("Just a few things I’ve collected in our short time here");

                //Show shop!

                while (!DialogueSkipped()) { yield return null; }

                break;

            case GameManager.Response.R3:
                NewDialogueOutput("Hope to see you again!");

                while (!DialogueSkipped()) { yield return null; }

                break;
        }

        response = GameManager.Response.None;

        EndInteractionWithResponse();
    }

    protected override void HandleCurrentInteraction() {
        StartCoroutine(Interaction());
    }
}

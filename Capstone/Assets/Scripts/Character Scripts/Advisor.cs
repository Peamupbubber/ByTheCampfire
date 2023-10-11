using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Advisor : NPC
{
    protected override void HandleCurrentInteraction()
    {
        StartCoroutine(FirstInteraction());
    }

    IEnumerator FirstInteraction() {
        StartInteractionWithResponse();

        NewDialogueOutput("Hey! Glad you're up, are you ready?");

        gameManager.SetResponseButtonText1("Yes!");
        gameManager.SetResponseButtonText2("Ready for what?");
        gameManager.SetResponseButtonText3("Who are you?");

        while(!PlayerResponded()) { yield return null; }

        switch (response) {
            case GameManager.Response.R1:
                NewDialogueOutput("Great! Let's get going then, I'll meet you out in the woods shortly.");

                break;

            case GameManager.Response.R2:
                NewDialogueOutput("Oh, you must've forgotten. I asked you to accompany me to gather some things for our camp, are you still up for that?");

                StartCoroutine(FirstInteractionO1());

                break;

            case GameManager.Response.R3:
                NewDialogueOutput("Oh, you don't remember me? I suppose we did only meet briefly the other day. I'm " + name +
                    ", I'll be showing you around camp as you get settled in and getting you started on your first few tasks here." +
                    "If you're ever looking for something do or have any questions just come to me!");

                while(!DialogueSkipped()) { yield return null; }

                NewDialogueOutput("On that note, if you're willing I'd like you to join me on a hunt for a few things today. Sound good?");

                StartCoroutine(FirstInteractionO1());

                break;
        }

        ClearResponse();

        while (altRoutineRunning) { yield return null; }
        while (!DialogueSkipped()) { yield return null; }

        NewDialogueOutput("But first, let me introduce you to someone. " /* + leader's name */);

        while (!DialogueSkipped()) { yield return null; }

        //Play animation of leader walking over

        NewDialogueOutput("Hey" /* + leader's name */ + ", this is " + playerInfo.playerName + "! " + playerInfo.GetASubjectPronoun(true) + 
            " will be joining me today on a hunt for some raw materials.");

        while (!DialogueSkipped()) { yield return null; }

        /* Leader */
        NewDialogueOutput("Good to meet you.");

        while (!DialogueSkipped()) { yield return null; }

        //Play animation of leader turning to advisor

        string subjPronoun = playerInfo.GetASubjectPronoun(false);
        string follow = subjPronoun.Equals("they") ? "are" : "is";

        NewDialogueOutput("Are you sure " + subjPronoun + " " + follow + " the right fit for this position?");

        while (!DialogueSkipped()) { yield return null; }

        /* Advisor */
        NewDialogueOutput("Well of course, I wouldn't have chosen " + playerInfo.GetAnObjectPronoun(false) + " otherwise!");

        while (!DialogueSkipped()) { yield return null; }

        /* Leader */
        NewDialogueOutput("Alright...");

        while (!DialogueSkipped()) { yield return null; }

        //Play animation of leader walking away

        /* Advisor */
        //Change leader's pronouns
        NewDialogueOutput("Don't mind them, they've just got a lot on his plate");

        while (!DialogueSkipped()) { yield return null; }

        NewDialogueOutput("Anyway, I'll meet you out there, and don't be a stranger to the other people in the camp, they'd love to get to know you!");

        while (!DialogueSkipped()) { yield return null; }

        //Play animation of advisor walking towards the woods

        EndInteractionWithResponse();
    }
    IEnumerator FirstInteractionO1() {
        altRoutineRunning = true;
        ClearResponse();
        gameManager.ClearResponseButtons();
        gameManager.SetResponseButtonText1("Yeah sure!");
        gameManager.SetResponseButtonText2("Actually, I think I'd rather take a look around town first.");

        while(!PlayerResponded()) { yield return null; }

        switch (response) {
            case GameManager.Response.R1:
                NewDialogueOutput("Great! I'll meet you out there once you're ready");
                break;

            case GameManager.Response.R2:
                NewDialogueOutput("Okay, well I'll meet you out there once you're ready.");
                break;
        }

        ClearResponse();

        while (!DialogueSkipped()) { yield return null; }
        altRoutineRunning = false;
    }
}

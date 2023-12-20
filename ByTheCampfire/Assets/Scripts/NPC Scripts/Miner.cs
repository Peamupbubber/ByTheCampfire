using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class Miner : NPC
{
    IEnumerator FirstInteraction() {
        StartInteractionWithResponse();

        NewDialogueOutput("Trip here was really something, eh?");

        gameManager.SetResponseButtonText1("Yeah, it was a lot bumpier than I expected..");
        gameManager.SetResponseButtonText2("Really? I slept right through it.");
        gameManager.SetResponseButtonText3("Who are you?");

        while (!PlayerResponded()) { yield return null; }

        switch (response) {
            case Response.R1:
                NewDialogueOutput("Agreed.");

                while (!DialogueSkipped()) { yield return null; }

                break;

            case Response.R2:
                NewDialogueOutput("Oh well aren't you cool.");

                while (!DialogueSkipped()) { yield return null; }

                break;

            case Response.R3:
                NewDialogueOutput("The name's " + npcName + ".");

                ClearResponse();

                gameManager.SetResponseButtonText1(npcName + ", I don't believe we've met.");
                gameManager.SetResponseButtonText2("Nice to meet you, I'm " + playerInfo.playerName + ".");

                while (!PlayerResponded()) { yield return null; }

                switch (response) {
                    case Response.R1:
                        NewDialogueOutput("I suppose not, but I remember you from the ship." +
                            "I only saw you passing in the halls, but I thought to myself," +
                            "\"" + playerInfo.pronounProcessor.GetASubjectPlusFollowingVerb(false, "look") + " like " +
                            playerInfo.pronounProcessor.GetASubjectAndToBeVerb(false) + " going to be quite the character\".");

                        ClearResponse();

                        gameManager.SetResponseButtonText1("What’s that supposed to mean?");

                        while (!PlayerResponded()) { yield return null; }

                        NewDialogueOutput("Nothing in particular, just that I expect big things from you.");

                        ClearResponse();

                        gameManager.SetResponseButtonText1("Well alright then, I’ll do my best…");

                        while (!PlayerResponded()) { yield return null; }

                        break;

                    case Response.R2:

                        NewDialogueOutput(playerInfo.playerName + ", huh? Well, good to meet you. I’ll be around if you ever need anything.");

                        ClearResponse();

                        gameManager.SetResponseButtonText1("Like what?");
                        gameManager.SetResponseButtonText2("Great!");

                        while (!PlayerResponded()) { yield return null; }

                        switch (response) {
                            case Response.R1:
                                NewDialogueOutput("Well, I lead the mining efforts here so if you need some resources or info on the mines I’m your guy.");

                                while (!DialogueSkipped()) { yield return null; }

                                break;
                        }

                        break;
                }

                break;
        }

        ClearResponse();

        EndInteractionWithResponse();
    }

    protected override void HandleCurrentInteraction() {
        StartCoroutine(FirstInteraction());
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class NPC : Interactable
{
    protected GameManager.Response response = GameManager.Response.None;
    [SerializeField] private GameObject responseButtons;

    /* Checks if the player has responded to a line of dialogue */
    protected bool PlayerResponded()
    {
        return response != GameManager.Response.None;
    }

    public void SetResponse(GameManager.Response newResponse) {
        response = newResponse;
    }

    protected void StartInteractionWithResponse()
    {
        StartInteraction();
        gameManager.SetCurrentNPC(this);
        responseButtons.gameObject.SetActive(true);
    }

    protected void EndInteractionWithResponse()
    {
        responseButtons.gameObject.SetActive(false);
        EndInteraction();
    }

}

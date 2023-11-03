using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class NPC : Interactable
{
    [HideInInspector] public GameManager.Response response = GameManager.Response.None;
    [SerializeField] private GameObject responseButtons;

    protected bool altRoutineRunning = false;

    private void Start()
    {
        responseButtons = GameObject.Find("Response Buttons");
    }

    /* Checks if the player has responded to a line of dialogue */
    protected bool PlayerResponded()
    {
        return response != GameManager.Response.None;
    }

    public void SetResponse(GameManager.Response newResponse) {
        response = newResponse;
    }

    public void ClearResponse() {
        response = GameManager.Response.None;
    }

    protected void StartInteractionWithResponse()
    {
        dialogueBox.transform.localPosition = gameManager.dialogueBoxResponseLocation;
        gameManager.SetCurrentNPC(this);
        responseButtons.gameObject.SetActive(true);
        StartInteraction();
    }

    protected void EndInteractionWithResponse()
    {
        responseButtons.gameObject.SetActive(false);
        EndInteraction();
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class NPC : Interactable
{
    [HideInInspector] public GameManager.Response response = GameManager.Response.None;

    protected bool altRoutineRunning = false;

    private SpriteRenderer torso;
    private SpriteRenderer top;
    private SpriteRenderer legs;

    private void OnEnable()
    {
        torso = transform.Find("Torso").gameObject.GetComponent<SpriteRenderer>();
        top = transform.Find("Top").gameObject.GetComponent<SpriteRenderer>();
        legs = transform.Find("Legs").gameObject.GetComponent<SpriteRenderer>();

        torso.color = Random.ColorHSV();
        top.color = Random.ColorHSV();
        legs.color = Random.ColorHSV();
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

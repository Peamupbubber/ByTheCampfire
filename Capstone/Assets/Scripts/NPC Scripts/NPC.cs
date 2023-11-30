using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;
using Random = UnityEngine.Random;
using SysRandom = System.Random;

[RequireComponent(typeof(PronounProcessor))]

/* the npcName field should be set in the inspector for each NPC */

public abstract class NPC : Interactable, Character
{
    [HideInInspector] public Response response = Response.None;

    protected bool altRoutineRunning = false;

    private SpriteRenderer torso;
    private SpriteRenderer top;
    private SpriteRenderer legs;

    public string npcName;
    private List<string[]> pronouns;
    private SysRandom rng = new SysRandom();

    [HideInInspector] public PronounProcessor pronounProcessor;

    protected new void Awake()
    {
        base.Awake();
        
        torso = transform.Find("Torso").gameObject.GetComponent<SpriteRenderer>();
        top = transform.Find("Top").gameObject.GetComponent<SpriteRenderer>();
        legs = transform.Find("Legs").gameObject.GetComponent<SpriteRenderer>();

        torso.color = Random.ColorHSV();
        top.color = Random.ColorHSV();
        legs.color = Random.ColorHSV();

        pronounProcessor = GetComponent<PronounProcessor>();
    }

    //Make sure to copy from Awake above if Interactable ever gets a Start()
    protected void Start()
    {
        response = Response.None;
        pronouns = gameManager.GetNPCPronounSet();
        //Debug.Log(GetPronoun(PlayerInfo.pronoun_type.SUBJECT, true)); //rm
    }

    /* Checks if the player has responded to a line of dialogue */
    protected bool PlayerResponded()
    {
        return response != Response.None;
    }

    public void SetResponse(Response newResponse) {
        response = newResponse;
    }

    public void ClearResponse() {
        response = Response.None;
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

    //For debugging
    private void PrintProns()
    {
        for (int i = 0; i < pronouns.Count; i++)
        {
            Debug.Log(pronouns[i][0] + ", " + pronouns[i][1] + ", " + pronouns[i][2]);
        }
    }

    public string GetPronoun(pronoun_type type, bool cap) {
        string pronoun = npcName;
        if (pronouns.Count > 0)
        {
            pronoun = pronouns[rng.Next(pronouns.Count)][(int)type];
            if (cap) pronoun = pronoun.ToUpper()[0] + pronoun.Substring(1);
        }

        return pronoun;
    }
}

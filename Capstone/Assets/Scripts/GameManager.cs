using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text responseButtonText1;
    [SerializeField] private TMP_Text responseButtonText2;
    [SerializeField] private TMP_Text responseButtonText3;
    [SerializeField] private TMP_Text responseButtonText4;

    [SerializeField] private TMP_Text dialogueBox;

    public NPC currentInteractionsNPC;

    public enum Response
    { 
        R1,
        R2,
        R3,
        R4,
        None
    }

    public void SetResponseButtonText1(string text)
    {
        responseButtonText1.text = text;
    }

    public void SetResponseButtonText2(string text)
    {
        responseButtonText2.text = text;
    }

    public void SetResponseButtonText3(string text)
    {
        responseButtonText3.text = text;
    }

    public void SetResponseButtonText4(string text)
    {
        responseButtonText4.text = text;
    }

    public void SetDialogueBoxText(string text) {
        dialogueBox.text = text;
    }

    public void SetCurrentNPC(NPC npc) {
        currentInteractionsNPC = npc;
    }

    public void Response1() { currentInteractionsNPC.SetResponse(Response.R1); }
    public void Response2() { currentInteractionsNPC.SetResponse(Response.R2); }
    public void Response3() { currentInteractionsNPC.SetResponse(Response.R3); }
    public void Response4() { currentInteractionsNPC.SetResponse(Response.R4); }

    public void ClearResponseButtons() {
        SetResponseButtonText1("");
        SetResponseButtonText2("");
        SetResponseButtonText3("");
        SetResponseButtonText4("");
    }
}

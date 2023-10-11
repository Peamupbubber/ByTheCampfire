using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject responseButtons;
    [SerializeField] private TMP_Text responseButtonText1;
    [SerializeField] private TMP_Text responseButtonText2;
    [SerializeField] private TMP_Text responseButtonText3;
    [SerializeField] private TMP_Text responseButtonText4;

    [SerializeField] private TMP_Text dialogueBox;
    public Vector3 dialogueBoxResponseLocation;
    public Vector3 dialogueBoxCenterLocation;

    public NPC currentInteractionsNPC;

    public enum Response { R1, R2, R3, R4, None }

    private void Start()
    {
        dialogueBoxResponseLocation = dialogueBox.transform.localPosition;
        dialogueBoxCenterLocation = new Vector3(0f, dialogueBox.transform.localPosition.y, dialogueBox.transform.localPosition.z);
    }

    public void SetResponseButtonText1(string text)
    {
        if (text != "")
        {
            responseButtonText1.text = text;
            responseButtonText1.transform.parent.gameObject.SetActive(true);
            SetResponseButtons();
        }
        else
            responseButtonText1.transform.parent.gameObject.SetActive(false);
    }

    public void SetResponseButtonText2(string text)
    {
        if (text != "")
        {
            responseButtonText2.text = text;
            responseButtonText2.transform.parent.gameObject.SetActive(true);
            SetResponseButtons();
        }
        else
            responseButtonText2.transform.parent.gameObject.SetActive(false);
    }

    public void SetResponseButtonText3(string text)
    {
        if (text != "")
        {
            responseButtonText3.text = text;
            responseButtonText3.transform.parent.gameObject.SetActive(true);
            SetResponseButtons();
        }
        else
            responseButtonText3.transform.parent.gameObject.SetActive(false);
    }

    public void SetResponseButtonText4(string text)
    {
        if (text != "")
        {
            responseButtonText4.text = text;
            responseButtonText4.transform.parent.gameObject.SetActive(true);
            SetResponseButtons();
        }
        else
            responseButtonText4.transform.parent.gameObject.SetActive(false);
    }

    private void SetResponseButtons() {
        dialogueBox.transform.localPosition = dialogueBoxResponseLocation;
        responseButtons.gameObject.SetActive(true);
    }

    public void SetDialogueBoxText(string text) {
        dialogueBox.text = text;
    }

    public void SetCurrentNPC(NPC npc) {
        currentInteractionsNPC = npc;
    }

    public void Response1()
    {
        if (responseButtonText1.text != "")
        {
            currentInteractionsNPC.SetResponse(Response.R1);
            ClearResponseButtons();
        }
    }
    public void Response2()
    {
        if (responseButtonText2.text != "")
        {
            currentInteractionsNPC.SetResponse(Response.R2);
            ClearResponseButtons();
        }
    }
    public void Response3()
    {
        if (responseButtonText3.text != "")
        {
            currentInteractionsNPC.SetResponse(Response.R3);
            ClearResponseButtons();
        }
    }
    public void Response4()
    {
        if (responseButtonText4.gameObject.activeSelf)
        {
            currentInteractionsNPC.SetResponse(Response.R4);
            ClearResponseButtons();
        }
    }

    public void ClearResponseButtons() {
        responseButtons.gameObject.SetActive(false);
        dialogueBox.transform.localPosition = dialogueBoxCenterLocation;
        SetResponseButtonText1("");
        SetResponseButtonText2("");
        SetResponseButtonText3("");
        SetResponseButtonText4("");
    }
}

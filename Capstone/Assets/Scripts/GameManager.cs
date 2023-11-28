using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private GameObject menuManager; //Might not need
    private GameObject menu;

    public GameObject responseButtons;
    [SerializeField] private TMP_Text responseButtonText1;
    [SerializeField] private TMP_Text responseButtonText2;
    [SerializeField] private TMP_Text responseButtonText3;
    [SerializeField] private TMP_Text responseButtonText4;

    public TextMeshProUGUI dialogueBox;
    public Vector3 dialogueBoxResponseLocation;
    public Vector3 dialogueBoxCenterLocation;

    public NPC currentInteractionsNPC;

    private GameObject player;
    private PlayerInfo playerInfo;

    public enum Response { R1, R2, R3, R4, None }

    private void Start()
    {
        Application.targetFrameRate = 60;
        DontDestroyOnLoad(gameObject);

        dialogueBoxResponseLocation = dialogueBox.transform.localPosition;
        dialogueBoxCenterLocation = new Vector3(0f, dialogueBox.transform.localPosition.y, dialogueBox.transform.localPosition.z);

        menuManager = GameObject.Find("Menu Manager");
        menu = menuManager.transform.Find("Menu").gameObject;

        player = GameObject.Find("Player");
        playerInfo = player.GetComponent<PlayerInfo>();
        player.SetActive(false);
        ClearResponseButtons();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !playerInfo.paused && dialogueBox.text == "") {
            menu.SetActive(!menu.activeSelf);
            playerInfo.PausePressed();
        }
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

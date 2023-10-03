using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    private Texture2D cursorTexture;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;

    [SerializeField] private TextMeshProUGUI dialogueBox;

    bool justClicked = false;

    private GameObject player;
    public PlayerInfo playerInfo;
    private Player playerScript;

    private bool response1Selected = false;
    private bool response2Selected = false;

    private void Awake()
    {
        player = GameObject.Find("Player");
        playerInfo = player.GetComponent<PlayerInfo>();
        playerScript = player.GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        cursorTexture = Texture2D.redTexture; //Temp texture
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (DialogueSkipped()) {
            dialogueBox.text = "";
        }
        */
    }

    public void response1() { response1Selected = true; }
    public void response2() { response2Selected = true; }

    private void Interaction() {
        /* Entering new interaction */
        playerScript.canMove = false;
        dialogueBox.gameObject.SetActive(true);


        NewDialogueOutput("Sample Text!");
        StartCoroutine(WaitForResponse());

        
    }

    IEnumerator WaitForResponse() {
        while (!response1Selected && !response2Selected) {
            yield return null;
        }

        if (response1Selected)
        {
            Debug.Log("Button 1 was clicked!");
            response1Selected = false;
        }
        else
        {
            Debug.Log("Button 2 was clicked!");
            response2Selected = false;
        }

        /* End of interaction */
        playerScript.canMove = true;
        dialogueBox.text = "";
        dialogueBox.gameObject.SetActive(false);
    }

    private void NewDialogueOutput(string output) {
        justClicked = true;

        //Write to dialogue bar in UI
        dialogueBox.text = output;

        //Allows player to click right click to go through dialogue
        StartCoroutine(WaitAfterClick());
    }

    private bool DialogueSkipped() {
        return dialogueBox.text != "" && !justClicked && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(1));
    }

    private void OnMouseOver()
    {
        //Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        if (Input.GetMouseButtonDown(1) && dialogueBox.text == "") {
            Debug.Log("clicked");
            Interaction();
        }
    }

    IEnumerator WaitAfterClick() {
        yield return new WaitForSeconds(0.3f);

        justClicked = false;
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(null, hotSpot, cursorMode);
    }
}

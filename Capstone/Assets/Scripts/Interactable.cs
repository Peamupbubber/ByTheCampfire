using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    /* All interactables must implement a way to handle their current interaction */
    protected abstract void HandleCurrentInteraction();


    /* For cursor stuff when I get there */
    private Texture2D cursorTexture;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;
    //cursorTexture = Texture2D.redTexture; //Something like this is in Start()

    protected GameManager gameManager;
    protected TextMeshProUGUI dialogueBox;

    private bool justClicked = false;
    private const float waitTimeAfterClick = 0.3f;

    protected GameObject player;
    protected PlayerInfo playerInfo;
    protected Player playerScript;

    private void Awake()
    {
        player = GameObject.Find("Player");
        playerInfo = player.GetComponent<PlayerInfo>();
        playerScript = player.GetComponent<Player>();

        gameManager = FindObjectOfType<GameManager>();

        dialogueBox = GameObject.Find("DialogueBox").GetComponent<TextMeshProUGUI>();
    }

    /* Writes the output string to the dialogue box and handles recent click waiting*/
    protected void NewDialogueOutput(string output)
    {
        justClicked = true;

        gameManager.SetDialogueBoxText(output);

        StartCoroutine(WaitAfterClick());
    }

    /* Adds a buffer of time after the npc is clicked on so that the click first click does not skip the dialogue */
    private IEnumerator WaitAfterClick()
    {
        yield return new WaitForSeconds(waitTimeAfterClick);

        justClicked = false;
    }

    /* Check if the player has skipped the current line of dialogue */
    protected bool DialogueSkipped()
    {
        return dialogueBox.text != "" && !justClicked && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(1));
    }

    /* Things that happen on every interaction beginning */
    protected void StartInteraction()
    {
        playerScript.canMove = false;
        dialogueBox.gameObject.SetActive(true);
    }

    /* Things that happen on every interaction ending */
    protected void EndInteraction()
    {
        playerScript.canMove = true;
        dialogueBox.text = "";
        dialogueBox.gameObject.SetActive(false);
    }

    private void OnMouseOver()
    {
        //Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        if (Input.GetMouseButtonDown(1) && dialogueBox.text == "")
        {
            HandleCurrentInteraction();
        }
    }

    /* For cursor stuff when I get there */
    private void OnMouseExit()
    {
        Cursor.SetCursor(null, hotSpot, cursorMode);
    }
}

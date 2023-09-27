using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    private Texture2D cursorTexture;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;

    [SerializeField] private TextMeshProUGUI outputText;

    bool justClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        cursorTexture = Texture2D.redTexture; //Temp texture
    }

    // Update is called once per frame
    void Update()
    {
        if (outputText.text != "" && !justClicked && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(1))) {
            outputText.text = "";
        }
    }

    private void OnMouseOver()
    {
        //Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        if (Input.GetMouseButtonDown(1) && outputText.text == "") {
            justClicked = true;

            //Write to dialogue bar in UI
            outputText.text = "Sample Text! Although this is probably way too long to fit in the box!";

            //Allows player to click right click to go through dialogue
            StartCoroutine(WaitAfterClick());
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

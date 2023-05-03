using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Texture2D cursorTexture;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        cursorTexture = Texture2D.redTexture; //Temp texture
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        if (Input.GetMouseButtonDown(1)) { 
            Debug.Log("Click");
            //Write to dialogue bar in UI
        }
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(null, hotSpot, cursorMode);
    }
}

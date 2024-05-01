using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private Canvas NPCPronounMenu;
    [SerializeField] Scrollbar NPCScrollbar;

    //This should mirror the chracter creation menu style

    public void EnableNPCPronounMenu()
    {
        NPCPronounMenu.enabled = true;
        //Need way to disable

        //Set the pronoun scrollbar to the top
        NPCScrollbar.value = 1.000001f;
    }
}

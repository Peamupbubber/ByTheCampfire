using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject cCMenu;

    [SerializeField] private GameObject settings;

    public void NewGame()
    {
        cCMenu.SetActive(true);
        GetComponent<Canvas>().enabled = false;
    }

    public void BackToStart()
    {
        settings.SetActive(false);
        GetComponent<Canvas>().enabled = true;
    }

    public void LoadGame()
    {
        Debug.Log("Not implemented");
    }
}

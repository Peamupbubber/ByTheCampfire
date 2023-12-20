using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject cCMenu;

    public void NewGame()
    {
        cCMenu.SetActive(true);
        GetComponent<Canvas>().enabled = false;
    }

    public void LoadGame() {
        Debug.Log("Not implemented");
    }
}

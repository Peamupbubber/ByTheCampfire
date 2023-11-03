using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    [SerializeField] private TMP_Text errorDisplayText;

    [SerializeField] private GameObject player;
    private Player playerScript;
    private PlayerInfo playerInfo;

    private void Awake()
    {
        playerInfo = player.GetComponent<PlayerInfo>();
        playerScript = player.GetComponent<Player>();
        menu = transform.Find("Menu").gameObject;
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        if (playerInfo.playerName == "")
        {
            errorDisplayText.text = "Player must have a name";
        }
        else
        {
            if(!SceneManager.GetActiveScene().name.Equals("Game"))
                scenesToLoad.Add(SceneManager.LoadSceneAsync("Game"));
            menu.SetActive(false);
            player.SetActive(true);
            playerScript.paused = false;
            if(playerInfo.pronounsChanged)
                playerInfo.CreatePronounQueue();
        }
    }
}

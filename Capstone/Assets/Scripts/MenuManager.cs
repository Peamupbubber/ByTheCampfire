using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    [SerializeField] private TMP_Text errorDisplayText;

    [SerializeField] private GameObject player;
    private PlayerInfo playerInfo;

    private void Awake()
    {
        playerInfo = player.GetComponent<PlayerInfo>();
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
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Game"));
            gameObject.SetActive(false);
            player.SetActive(true);
        }
    }
}

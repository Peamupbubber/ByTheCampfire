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
    private PlayerInfo playerInfo;

    [SerializeField] private PlayerPreview playerPreview;

    private void Awake()
    {
        playerInfo = player.GetComponent<PlayerInfo>();
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
        else if (!HasCompleteSprite())
        {
            errorDisplayText.text = "Player must have a complete sprite";
        }
        else
        {
            if (!SceneManager.GetActiveScene().name.Equals("Game"))
                scenesToLoad.Add(SceneManager.LoadSceneAsync("Game"));
            menu.SetActive(false);
            player.SetActive(true);
            playerInfo.paused = false;
            if (playerInfo.pronounsChanged)
                playerInfo.CreatePronounQueue();
        }
    }

    //This will need to change when hair is added. Also could maybe be more modular somehow
    public bool HasCompleteSprite()
    {
        return playerPreview.legsImage.enabled && playerPreview.topImage.enabled && playerPreview.torsoImage.enabled;
    }
}

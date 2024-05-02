using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject pause;

    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    [SerializeField] private TMP_Text errorDisplayText;

    [SerializeField] private GameObject player;
    private PlayerInfo playerInfo;

    [SerializeField] private PlayerPreview playerPreview;

    private void Awake()
    {
        playerInfo = player.GetComponent<PlayerInfo>();
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settings.activeSelf)
            {
                settings.SetActive(false);
                if(!SceneManager.GetActiveScene().name.Equals("Menu"))
                    pause.SetActive(true);
            }
            else if (menu.activeSelf && !SceneManager.GetActiveScene().name.Equals("Menu"))
            {
                menu.SetActive(false);
                pause.SetActive(true);
            }
            else if(GameManager.gameManager.CanPause())
            {
                pause.SetActive(!pause.activeSelf);
                playerInfo.PausePressed();
            }
        }
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

    public void Resume() {
        pause.SetActive(false);
        playerInfo.PausePressed();
    }

    public void Creation() {
        pause.SetActive(false);
        menu.SetActive(true);
    }

    public void Settings() {
        pause.SetActive(false);
        settings.SetActive(true);
    }

    public void ExitGame() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    //This will need to change when hair is added. Also could maybe be more modular somehow
    public bool HasCompleteSprite()
    {
        return playerPreview.legsImage.enabled && playerPreview.topImage.enabled && playerPreview.torsoImage.enabled;
    }
}

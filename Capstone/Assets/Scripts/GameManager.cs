using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    [SerializeField] private TMP_Text errorDisplayText;

    [SerializeField] private GameObject player;
    private PlayerInfo playerInfo;

    private void Awake()
    {
        playerInfo = player.GetComponent<PlayerInfo>();
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        if (playerInfo.playerName == "" || playerInfo.numPronouns == 0)
        {
            errorDisplayText.text = "Player must have a name and at least one set of pronouns";
        }
        else {
            scenesToLoad.Add(SceneManager.LoadSceneAsync("SampleScene"));
            player.SetActive(true);
        }
    }
}

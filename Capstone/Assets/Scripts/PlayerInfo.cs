using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{

    public string playerName;

    public List<string> playerSubjectPronouns;
    public List<string> playerObjectPronouns;
    public List<string> playerPossessivePronouns;
    public int numPronouns;

    [SerializeField] private TMP_InputField playerNameInputField;


    public void InitializeNewPronounLists() {
        playerSubjectPronouns = new List<string>();
        playerObjectPronouns = new List<string>();
        playerPossessivePronouns = new List<string>();
        numPronouns = 0;
    }

    public void UpdatePlayerName() {
        playerName = playerNameInputField.text;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreation : MonoBehaviour
{
    [SerializeField] private Canvas nameMenu;
    [SerializeField] private Canvas pronounMenu;
    [SerializeField] private Canvas appearanceMenu;
    [SerializeField] private Canvas colorsMenu;
    [SerializeField] private Canvas startMenu;

    private Canvas currentlyEnabledCanvas;

    [SerializeField] private TMP_InputField playerNameInputField;

    [SerializeField] private TMP_Text pronounDisplayText;
    [SerializeField] private TMP_Text errorDisplayText;

    private PronounGen pronounGen;

    [SerializeField] GameObject playerPreview;
    [SerializeField] GameObject previewColorHeader;

    [SerializeField] private GameObject player;
    private PlayerInfo playerInfo;

    private void Awake()
    {
        playerInfo = player.GetComponent<PlayerInfo>();
        pronounGen = GetComponent<PronounGen>();
    }

    // Enable the correct canvases and objects
    void Start()
    {
        nameMenu.enabled = true;
        pronounMenu.enabled = false;
        appearanceMenu.enabled = false;
        colorsMenu.enabled = false;
        startMenu.enabled = false;

        currentlyEnabledCanvas = nameMenu;
        previewColorHeader.SetActive(false);
        playerPreview.SetActive(false);
    }

    public void EnableNameMenu() {
        bool err = MenuChanged(true, false);
        if (err) return;

        nameMenu.enabled = true;
        currentlyEnabledCanvas = nameMenu;
    }

    public void EnablePronounMenu() {
        bool err = MenuChanged(false, false);
        if (err) return;

        pronounGen.UpdateDisplayText();

        pronounMenu.enabled = true;
        currentlyEnabledCanvas = pronounMenu;
    }

    public void EnableAppearanceMenu() {
        bool err = MenuChanged(false, true);
        if (err) return;

        appearanceMenu.enabled = true;
        currentlyEnabledCanvas = appearanceMenu;
    }

    public void EnableColorsMenu()
    {
        bool err = MenuChanged(false, true);
        if (err) return;

        previewColorHeader.SetActive(true);
        colorsMenu.enabled = true;
        currentlyEnabledCanvas = colorsMenu;
    }

    public void EnableStartMenu()
    {
        bool err = MenuChanged(false, false);
        if (err) return;

        startMenu.enabled = true;
        currentlyEnabledCanvas = startMenu;
    }

    //Called any time a menu is changed, returns true if there is an error and the menu cannot be changed
    private bool MenuChanged(bool fromName, bool enableSprite)
    {
        if (!fromName && currentlyEnabledCanvas.Equals(nameMenu) && playerInfo.playerName == "")
        {
            errorDisplayText.text = "Player must have a name";
            return true;
        }

        errorDisplayText.text = "";

        //Things that always happen if menu changed successfully
        currentlyEnabledCanvas.enabled = false;
        playerPreview.gameObject.SetActive(enableSprite);
        previewColorHeader.SetActive(false);

        return false;
    }

    //Called by on value changed in player name input field
    public void UpdatePlayerName() {
        playerInfo.UpdatePlayerName(playerNameInputField.text);
    }
}

using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        currentlyEnabledCanvas = nameMenu;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableNameMenu() {
        currentlyEnabledCanvas.enabled = false;

        nameMenu.enabled = true;
        currentlyEnabledCanvas = nameMenu;
    }

    public void EnablePronounMenu() {
        currentlyEnabledCanvas.enabled = false;

        pronounMenu.enabled = true;
        currentlyEnabledCanvas = pronounMenu;
    }

    public void EnableAppearanceMenu() {
        currentlyEnabledCanvas.enabled = false;

        appearanceMenu.enabled = true;
        currentlyEnabledCanvas = appearanceMenu;
    }

    public void EnableColorsMenu()
    {
        currentlyEnabledCanvas.enabled = false;

        colorsMenu.enabled = true;
        currentlyEnabledCanvas = appearanceMenu;
    }

    public void EnableStartMenu()
    {
        currentlyEnabledCanvas.enabled = false;

        startMenu.enabled = true;
        currentlyEnabledCanvas = appearanceMenu;
    }


}

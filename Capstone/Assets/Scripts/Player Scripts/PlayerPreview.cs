using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPreview : MonoBehaviour
{
    public enum appearance_type { LEGS, TOP, TORSO, NONE }

    appearance_type currentlySelected = appearance_type.NONE;

    public Image legsImage;
    public Image topImage;
    public Image torsoImage;

    [SerializeField] private PlayerLegs playerLegs;
    [SerializeField] private PlayerTop playerTop;
    [SerializeField] private PlayerTorso playerTorso;

    [SerializeField] private Sprite[] legs;
    [SerializeField] private Sprite[] tops;
    [SerializeField] private Sprite[] torsos;

    //Defaults to white so that it doesn't change the color of the original sprite
    private Color legsColor = Color.white;
    private Color topColor = Color.white;
    private Color torsoColor = Color.white;

    //Note: Change first entry in list once a new set of sprites is available

    //Note: Torso is in behind the chest for the preview becuase it covers the chests clickable area. Change later.

    //Note for presentation: purposfully not having a default sprite

    public void SetLegs(int i) {
        if (legsImage.enabled == false)
            legsImage.enabled = true;
        legsImage.sprite = legs[i];
        SetLegsColor(legsColor);
        playerLegs.SetLegAnimation(i);
    }

    public void SetTop(int i) {
        if (topImage.enabled == false)
            topImage.enabled = true;
        topImage.sprite = tops[i];
        SetTopColor(topColor);
        playerTop.SetTopAnimation(i);
    }

    public void SetTorso(int i) {
        if (torsoImage.enabled == false)
            torsoImage.enabled = true;
        torsoImage.sprite = torsos[i];
        SetTorsoColor(torsoColor);
        playerTorso.SetTorsoAnimation(i);
    }

    public void SetLegsColor(Color newColor) {
        legsImage.color = newColor;
        legsColor = newColor;
        playerLegs.SetColor(newColor);
    }

    public void SetTopColor(Color newColor)
    {
        topImage.color = newColor;
        topColor = newColor;
        playerTop.SetColor(newColor);
    }

    public void SetTorsoColor(Color newColor)
    {
        torsoImage.color = newColor;
        torsoColor = newColor;
        playerTorso.SetColor(newColor);
    }

    public void SetColor(Color newColor) {
        switch (currentlySelected) {
            case appearance_type.LEGS:
                SetLegsColor(newColor);
                break;

            case appearance_type.TOP:
                SetTopColor(newColor);
                break;

            case appearance_type.TORSO:
                SetTorsoColor(newColor);
                break;
        }
    }

    public void SetCurrentlySelected(int type) {
        currentlySelected = (appearance_type)type;
    }
}

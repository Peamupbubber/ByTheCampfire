using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPreview : MonoBehaviour
{
    public enum appearance_type { LEGS, TOP, TORSO, HAIR, NONE }

    appearance_type currentlySelected = appearance_type.NONE;

    public Image hairImage;
    public Image torsoImage;
    public Image topImage;
    public Image legsImage;

    [SerializeField] private PlayerSprite playerHair;
    [SerializeField] private PlayerSprite playerTorso;
    [SerializeField] private PlayerSprite playerTop;
    [SerializeField] private PlayerSprite playerLegs;

    [SerializeField] private Image torsoSelectedImage;
    [SerializeField] private Image topSelectedImage;
    [SerializeField] private Image legsSelectedImage;
    [SerializeField] private Image hairSelectedImage;

    [SerializeField] private Sprite[] hairs;
    [SerializeField] private Sprite[] torsos;
    [SerializeField] private Sprite[] tops;
    [SerializeField] private Sprite[] legs;

    //Defaults to white so that it doesn't change the color of the original sprite
    private Color torsoColor = Color.white;
    private Color topColor = Color.white;
    private Color legsColor = Color.white;
    private Color hairColor = Color.white;

    //Note: Change first entry in list once a new set of sprites is available

    //Note: Torso is in behind the chest for the preview becuase it covers the chests clickable area. Change later.

    //Note for presentation: purposfully not having a default sprite

    //The player can chose to have no hair for their character
    public void SetHair(int i)
    {
        if (i == 0)
        {
            hairImage.enabled = false;
            hairSelectedImage.enabled = false;
            hairImage.sprite = null;
        }
        else
        { 
            i--;
            if (!hairImage.enabled)
                hairImage.enabled = true;
            hairImage.sprite = hairs[i];
            SetHairColor(hairColor);
            //playerHair.SetAnimation(i); uncomment when hair anims are a thing        
        }

    }

    public void SetTorso(int i) {
        if (!torsoImage.enabled)
            torsoImage.enabled = true;
        torsoImage.sprite = torsos[i];
        SetTorsoColor(torsoColor);
        playerTorso.SetAnimation(i);
    }

    public void SetTop(int i)
    {
        if (!topImage.enabled)
            topImage.enabled = true;
        topImage.sprite = tops[i];
        SetTopColor(topColor);
        playerTop.SetAnimation(i);
    }

    public void SetLegs(int i)
    {
        if (!legsImage.enabled)
            legsImage.enabled = true;
        legsImage.sprite = legs[i];
        SetLegsColor(legsColor);
        playerLegs.SetAnimation(i);
    }

    public void SetHairColor(Color newColor)
    {
        hairImage.color = newColor;
        hairColor = newColor;
        //playerHair.SetColor(newColor);
    }

    public void SetTorsoColor(Color newColor)
    {
        torsoImage.color = newColor;
        torsoColor = newColor;
        playerTorso.SetColor(newColor);
    }

    public void SetTopColor(Color newColor)
    {
        topImage.color = newColor;
        topColor = newColor;
        playerTop.SetColor(newColor);
    }

    public void SetLegsColor(Color newColor) {
        legsImage.color = newColor;
        legsColor = newColor;
        playerLegs.SetColor(newColor);
    }

    public void SetColor(Color newColor) {
        switch (currentlySelected) {
            case appearance_type.HAIR:
                SetHairColor(newColor);
                break;
            case appearance_type.TORSO:
                SetTorsoColor(newColor);
                break;
            case appearance_type.TOP:
                SetTopColor(newColor);
                break;
            case appearance_type.LEGS:
                SetLegsColor(newColor);
                break;
        }
    }

    //Called by clicking on the pieces of the sprites in the colors menu
    public void SetCurrentlySelected(int type) {
        currentlySelected = (appearance_type)type;
        switch ((appearance_type)type) {
            case appearance_type.HAIR:
                hairSelectedImage.enabled = true;
                torsoSelectedImage.enabled = false;
                topSelectedImage.enabled = false;
                legsSelectedImage.enabled = false;
                break;
            case appearance_type.TORSO:
                hairSelectedImage.enabled = false;
                torsoSelectedImage.enabled = true;
                topSelectedImage.enabled = false;
                legsSelectedImage.enabled = false;
                break;
            case appearance_type.TOP:
                hairSelectedImage.enabled = false;
                torsoSelectedImage.enabled = false;
                topSelectedImage.enabled = true;
                legsSelectedImage.enabled = false;
                break;
            case appearance_type.LEGS:
                hairSelectedImage.enabled = false;
                torsoSelectedImage.enabled = false;
                topSelectedImage.enabled = false;
                legsSelectedImage.enabled = true;
                break;
            default:
                Debug.Log("This should never happen");
                break;
        }
    }
}

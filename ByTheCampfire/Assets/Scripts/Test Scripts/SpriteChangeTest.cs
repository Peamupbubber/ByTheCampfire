using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChangeTest : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private PlayerSprite playerSprite;

    private int index = 0;
    private Image image;

    //Each preview element will have one of these scripts, then another script will grab the spriteIndex from here and send it to the player
    
    private void Start()
    {
        image = GetComponent<Image>();
        transform.Find("Left").GetComponent<Button>().onClick.AddListener(SpriteLeftShift);
        transform.Find("Right").GetComponent<Button>().onClick.AddListener(SpriteRightShift);
    }

    private void SpriteLeftShift() {
        ChangeSprite(-1);
    }

    private void SpriteRightShift() {
        ChangeSprite(1);
    }

    private void ChangeSprite(int dir) {
        //Remove this if it's too confusing that it doesn't have a starting value
        // default = bad?
        if (!image.enabled) {
            image.sprite = sprites[0];
            image.enabled = true;
        }
        else {        
            index += dir;
            if (index < 0)
                index = sprites.Length - 1;
            else if (index >= sprites.Length)
                index = 0;

            image.sprite = sprites[index];
            playerSprite.SetAnimation(index);
            //Need to set the color?
        }

    }
}

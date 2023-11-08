using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMovement : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private float facingX = 1;
    private float facingY = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float xDir = Input.GetAxis("Horizontal");
        if (xDir != 0)
        {
            if (xDir > 0)
                facingX = 1;
            else
                facingX = -1;
            anim.SetBool("Walking", true);
            spriteRenderer.flipX = facingX == -1 ? true : false;
            facingY = 0;
        }
        else
            anim.SetBool("Walking", false);

        float yDir = Input.GetAxis("Vertical");
        if (yDir != 0) {
            if (yDir > 0)
                facingY = 1;
            else
                facingY = -1;
        }
        anim.SetFloat("Direction", facingY);
    }
    
}

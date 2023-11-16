using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMovement : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private PlayerInfo playerInfo;

    [SerializeField] private float speed = 2f;

    private float facingX = 1;
    private float facingY = 0;

    //Rigt now the translate is applied for each sprite. no. make it different

    void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerInfo = transform.parent.GetComponent<PlayerInfo>();
    }

    void Update()
    {
        if(playerInfo.canMove && !playerInfo.paused)
            Move();
    }

    private void Move()
    {
        float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");

        DetermineAnim(xDir, yDir);

        Vector2 movement = new Vector2(xDir, yDir);
        transform.parent.Translate(movement * Time.deltaTime * speed);
    }


    private void DetermineAnim(float xDir, float yDir) {
        if (xDir != 0 || yDir != 0)
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

        if (yDir != 0)
        {
            if (yDir > 0)
                facingY = 1;
            else
                facingY = -1;
        }
        //Priority is given to horizontal movement
        if (xDir != 0)
            facingY = 0;
        anim.SetFloat("Direction", facingY);
    }
    
}

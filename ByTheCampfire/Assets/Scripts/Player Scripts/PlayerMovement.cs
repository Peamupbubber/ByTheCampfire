using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInfo playerInfo;

    //These 3 scripts could be changed to one script with 3 different objs
    [SerializeField] private PlayerSprite torso;
    [SerializeField] private PlayerSprite top;
    [SerializeField] private PlayerSprite legs;

    [SerializeField] private float speed;

    private float facingX = 1;
    private float facingY = 0;

    void Awake()
    {
        playerInfo = GetComponent<PlayerInfo>();
    }

    void Update()
    {
        if (playerInfo.canMove && !playerInfo.paused)
            Move();
    }

    private void Move()
    {
        float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");

        DetermineAnim(xDir, yDir);

        Vector2 movement = new Vector2(xDir, yDir);
        transform.Translate(movement * Time.deltaTime * speed);
    }

    private void DetermineAnim(float xDir, float yDir)
    {
        if (xDir != 0 || yDir != 0)
        {
            if (xDir > 0)
                facingX = 1;
            else
                facingX = -1;

            torso.SetAnimWalking(true);
            torso.SetSpriteFlip(facingX == -1);

            top.SetAnimWalking(true);
            top.SetSpriteFlip(facingX == -1);

            legs.SetAnimWalking(true);
            legs.SetSpriteFlip(facingX == -1);

            facingY = 0;
        }
        else
            Idle();

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

        torso.SetAnimDirection(facingY);
        top.SetAnimDirection(facingY);
        legs.SetAnimDirection(facingY);
    }

    public void Idle() {
        torso.SetAnimWalking(false);
        top.SetAnimWalking(false);
        legs.SetAnimWalking(false);
    }
}

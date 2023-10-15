using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Sprite idle_f;
    [SerializeField] private Sprite idle_l;
    [SerializeField] private Sprite idle_r;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float xDir = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.S))
            animator.SetTrigger("IdleIdle");
        else
        {
            if (xDir > 0)
            {
                animator.SetTrigger("Right Walk");
            }
            else if (xDir < 0)
            {
                animator.SetTrigger("Left Walk");
            }

            else
            {
                animator.SetTrigger("Idle");
            }
        }

    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    
    public Animator animator;

    bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (!facingRight)
            {
                Vector3 currentScale = gameObject.transform.localScale;
                currentScale.x *= -1;
                gameObject.transform.localScale = currentScale;
                facingRight = true;
            }
            animator.SetTrigger("Move");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (facingRight)
            {
                Vector3 currentScale = gameObject.transform.localScale;
                currentScale.x *= -1;
                gameObject.transform.localScale = currentScale;
                facingRight = false;
            }
            animator.SetTrigger("Move");
        }
        else {
            animator.SetTrigger("Stop Moving");
        }
    }
    
}

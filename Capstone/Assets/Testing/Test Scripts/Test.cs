using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Test : MonoBehaviour
{

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetTrigger("Move");
        }
        else if (Input.GetKeyDown(KeyCode.A)) {
            //transform.rotation.y = 180;
            Vector3 currentScale = gameObject.transform.localScale;
            currentScale.x *= -1;
            gameObject.transform.localScale = currentScale;
            animator.SetTrigger("Move");
        }
    }
}

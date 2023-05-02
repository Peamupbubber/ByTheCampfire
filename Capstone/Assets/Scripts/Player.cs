using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Rigidbody2D playerRb;
    [SerializeField] private float speed;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        //playerRb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 1.5f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 1.5f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        gameObject.transform.position = new Vector3(gameObject.transform.position.x + horizontal * Time.deltaTime * speed, gameObject.transform.position.y + vertical * Time.deltaTime * speed);
    }
}

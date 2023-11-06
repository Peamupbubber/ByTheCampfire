using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;

    [HideInInspector] public bool canMove = true;
    [HideInInspector] public bool paused = true;

    // Update is called once per frame
    void Update()
    {
        if (canMove && !paused) Move();
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

    public void PausePressed() {
        paused = !paused;
    }
}

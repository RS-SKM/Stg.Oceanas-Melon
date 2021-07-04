using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public bool godMode;
    private Rigidbody2D rb;
    private GameObject player;

    private Vector2 moveDirection;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        ProcessInput();

        if(Input.GetKeyDown(KeyCode.W))
        {
            rb.simulated = true; //turn on collision for 2D object only
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (godMode == true)
        {
            rb.simulated = false; //turn off collision 
        }
        if (godMode == false)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}

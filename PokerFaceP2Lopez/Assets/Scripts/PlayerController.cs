using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody2D rb2d;
    public Transform ceilingCheck;
    public Transform groundCheck; 

    public float UpForce = 200f;
    public float moveSpeed;
    public float jumpForce; 
    private float moveDirection;

    private bool isJumping = false;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ProcessInputs();
    }
    
    void FixedUpdate()
    {
        Move();
    }
    // Update is called once per frame
    private void Move()
    {
        moveDirection = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(moveDirection * moveSpeed, rb2d.velocity.y);
        if (isJumping)
        {
            rb2d.AddForce(new Vector2(0, jumpForce));
        }
        isJumping = false; 
    }
    private void ProcessInputs()
    {
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }   
    }
    //include health, change health component, maxhealth, and playsound
}

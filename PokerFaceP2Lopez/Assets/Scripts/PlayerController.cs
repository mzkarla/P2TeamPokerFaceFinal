using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody2D rb2d;

    //to make the player know its top from bottom
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;
    //layers, new, ground, and assign. then back in the inspector assign this to ground.   

    public float UpForce = 200f;
    public float moveSpeed;
    public float jumpForce;
    public float checkRadius; 
    private float moveDirection;
    //to move and jump

    public int maxjumpCount; 
    private int jumpCount; 
    //can jump however many times it wants


    private bool isJumping = false;
    private bool isGrounded;

    public Animator anim;

    private AudioSource jumpSoundEffect;



    //HEALTH
    public int maxHealth = 3;
    public int currentHealth;

    private void Start()
    {
        jumpCount = maxjumpCount;
        currentHealth = maxHealth; 
    }

    //made for health to take damage when run into obstacles
    void TakeDamage(int amount)
    {
        currentHealth -= amount; 

        if(currentHealth <= 0)
        {
            //We're dead
            //Play dead animation
            anim.SetBool("IsDead", true); 
        }

    }

    void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

    }

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ProcessInputs();
        //referencing to jump
    }
    
    void FixedUpdate()
    {
        //check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        if(isGrounded)
        {
            jumpCount = maxjumpCount; 
        }

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
            jumpCount--; 
        }
        isJumping = false; 
    }
    private void ProcessInputs()
    {
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpSoundEffect.Play(); 
            isJumping = true;
        }   
    }
    //include health, change health component,  and playsound
}

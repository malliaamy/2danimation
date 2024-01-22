using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public GameObject myAnimatedGameObject;
    Animator animator;
    private float horizontal;
    public float speed = 4f;

    public GameObject bullet;

    private float animationSpeed;
    float currentSpeed;
    public float walkSpeed;
    public float runSpeed;

    public GameObject BulletSpawn;
    public float jumpingPower = 5f;
    private bool isFacingRight = true;
    private bool isGrounded;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Awake()
    {
        animator = myAnimatedGameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // Ground Check

        IsGrounded();

        // Input

        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpState();
            // Trigger the "FrontJumping" trigger parameter in the Animator

        //    isJumping = true;
        }
         if (Input.GetKey(KeyCode.LeftShift))
        {
            // Set the running speed when the "Shift" key is held down
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }

        // Animation Move

        animationSpeed = Mathf.Abs(horizontal)*currentSpeed;
        animator.SetFloat("Speed",animationSpeed);
        
        
        
        
        
        /*
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        */



        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Shoot ");
        }
    }

    private void FixedUpdate()
    {
        if(animationSpeed > 0)
        rb.MovePosition(rb.position + new Vector2(horizontal * speed *currentSpeed, 0));
    }

    private void IsGrounded()
    {
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector3.down, 0.2f, groundLayer);
        Debug.DrawRay(groundCheck.position, Vector3.down * 0.2f, Color.red );
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void JumpState()
    {
            rb.AddForce(new Vector2(0,jumpingPower),  ForceMode2D.Impulse);
            animator.SetTrigger("Jump");    
            
    }

    public void FireSpawn()
    {
        Instantiate(bullet, BulletSpawn.transform.position, Quaternion.identity);
    }
}
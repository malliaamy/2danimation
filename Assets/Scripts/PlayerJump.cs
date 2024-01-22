using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{   private Animator animator;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance = 0.2f;

    private bool isJumping = false;

    void Start()
    {
        // Get the Animator component attached to the player GameObject
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check for space bar input
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            // Trigger the "FrontJumping" trigger parameter in the Animator
            animator.SetTrigger("Jump");
        //    isJumping = true;
        }

        // Add additional logic to handle the moving animation based on your game's movement controls
        // For example, you might have a condition to trigger the moving animation based on player input.
        // Replace this with your actual movement logic.
        //float horizontalInput = Input.GetAxis("Horizontal");
        //animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        // Perform the ground check
        //PerformGroundCheck();
    }

    void PerformGroundCheck()
    {
        // Cast a ray downward to check if the player is grounded
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

        // If the ray hits something, the player is considered grounded
        bool isGrounded = hit.collider != null;

        // Set the "IsGrounded" parameter in the Animator
        animator.SetBool("frontjumping", isGrounded);

        // If the player is grounded and was previously jumping, transition back to the moving state
        if (isGrounded && isJumping)
        {
            AnimationEvent_EndFrontJump();
        }
    }

    // Animation Event method to transition back to the moving state
    void AnimationEvent_EndFrontJump()
    {
        // This method will be called from an Animation Event at the end of the FrontJumping animation
        // Add any additional logic here to transition back to the moving state if needed
        float horizontalInput = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        // Reset the "FrontJumping" trigger
        animator.ResetTrigger("frontjumping");

        // Reset the jumping flag
        isJumping = false;
    }
}

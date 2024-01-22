using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
     private Animator animator;

    public float walkingSpeedMultiplier = .5f; // Adjust this value to control walking speed
    public float runningSpeedMultiplier = 1f; // Adjust this value to control running speed

    private bool run = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
       // Check if the "Left Shift" or "Right Shift" key is pressed
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            // Set a higher speed value when the Shift key is pressed to favor the "run" animation
            animator.SetFloat("Speed", 1.0f);
        }
        else
        {
            // Set the regular speed value based on the input axes when the Shift key is not pressed
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            float speed = Mathf.Sqrt(horizontalInput * horizontalInput + verticalInput * verticalInput);
            animator.SetFloat("Speed", speed);
        }
        
    }


    void UpdateAnimatorParameters(float horizontalInput)
    {
        // Set the "Speed" parameter based on the horizontal input
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
    }
}
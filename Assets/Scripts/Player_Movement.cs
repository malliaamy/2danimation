using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

      public float walkingSpeed = 0.1f;  // Set your desired walking speed
    public float runningSpeed = 0.5f;  // Set your desired running speed

    private float currentSpeed;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentSpeed = walkingSpeed;  // Set the default speed
        animator.SetFloat("Speed", currentSpeed);
    }

    void Update()
    {
        
        // Get input for movement (assuming 'Horizontal' axis for simplicity)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Check if the "Shift" key is held down
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // Set the running speed when the "Shift" key is held down
            currentSpeed = runningSpeed;
        }
        else
        {
            // Set the walking speed when the "Shift" key is not held down
            currentSpeed = walkingSpeed;
        }

        // Move the player based on the input and current speed
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);
        transform.Translate(movement * currentSpeed * Time.deltaTime);

        // Update animator parameters based on input
        UpdateAnimatorParameters(horizontalInput);
    }

    void UpdateAnimatorParameters(float horizontalInput)
    {
        // Set the "Speed" parameter based on the horizontal input and current speed
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput) * currentSpeed);
    }
        
    }


   
   

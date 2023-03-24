using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Player movement speed
    public float gravity = -9.81f; // Gravity force
    public float jumpHeight = 2f; // Jump height

    CharacterController controller;
    Vector3 velocity; // Player velocity vector

    void Start()
    {
        controller = GetComponent<CharacterController>(); // Get reference to player's CharacterController component
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Get horizontal input from keyboard
        float verticalInput = Input.GetAxis("Vertical"); // Get vertical input from keyboard

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput); // Create movement vector from input
        movement = transform.TransformDirection(movement); // Transform movement vector from local space to world space
        movement *= moveSpeed * Time.deltaTime; // Apply speed to movement vector

        if (controller.isGrounded) // Check if player is on ground
        {
            velocity.y = 0f; // Reset y velocity

            if (Input.GetButtonDown("Jump")) // Check for jump input
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // Calculate initial jump velocity
            }
        }

        velocity.y += gravity * Time.deltaTime; // Apply gravity to y velocity
        movement += velocity * Time.deltaTime; // Add gravity to movement vector

        controller.Move(movement); // Move player using CharacterController component
    }
}

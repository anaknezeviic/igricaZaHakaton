using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f; // Player movement speed

    public CharacterController controller;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Get horizontal input from keyboard
        float verticalInput = Input.GetAxis("Vertical"); // Get vertical input from keyboard

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput); // Create movement vector from input
        movement = transform.TransformDirection(movement); // Transform movement vector from local space to world space
        movement *= moveSpeed * Time.deltaTime; // Apply speed to movement vector

        controller.Move(movement); // Move player using CharacterController component
    }
}

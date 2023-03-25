using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // The speed of the object
    public float jumpForce = 10f; // The force of the jump
    private Rigidbody rb; // Reference to the Rigidbody component

    private void Start()
    {
        // Get the reference to the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Get the horizontal and vertical input axis
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Create a movement vector based on the input and the speed
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.fixedDeltaTime;

        // Apply the movement vector to the Rigidbody component
        rb.MovePosition(rb.position + movement);

        // Check if the player presses the Jump button
        if (Input.GetButtonDown("Jump"))
        {
            // Apply an upward force to the Rigidbody component
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "door")
        {
            System.Random random = new System.Random();
            int randomNumber = random.Next(1, 4);
            if(randomNumber == 2)
                GameBehavior.Instance.SceneToMoveTo("dobraScena");
            else
            {
                string[] KVIZ = {"KVIZ", "KVIZ 1", "KVIZ 2", "KVIZ 3", "KVIZ 4", "KVIZ 5"};
                randomNumber = random.Next(1, 7);
                GameBehavior.Instance.SceneToMoveTo(KVIZ[randomNumber-1]);
            }
        }
    }
}

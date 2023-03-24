using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 100f; // Mouse sensitivity
    public Transform playerBody; // Reference to player object
    float xRotation = 0f; // Current x rotation of camera

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center of screen
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime; // Get mouse movement on x axis
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime; // Get mouse movement on y axis

        xRotation -= mouseY; // Rotate camera on x axis
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limit camera rotation to prevent upside-down view

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Apply x rotation to camera

        playerBody.Rotate(Vector3.up * mouseX); // Rotate player object on y axis based on mouse movement
    }
}

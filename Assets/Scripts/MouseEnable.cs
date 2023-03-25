using UnityEngine;

public class MouseEnable : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true; // Set the cursor to be visible
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
    }
}
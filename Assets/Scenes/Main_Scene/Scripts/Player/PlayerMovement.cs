using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // A reference to the custom input actions, used to handle player inputs
    private Custominput input = null;

    // A 2D vector to store the player's movement input
    private Vector2 moveVector = Vector2.zero;

    // Reference to the Rigidbody2D component, used to apply physics-based movement
    private Rigidbody2D rb = null;

    // Speed at which the player moves
    private float moveSpeed = 10f;

    // Variable to store the camera's bounds
    private Camera mainCamera;

    private Animator animator = null;

    private void Awake()
    {
        // Initialize the input system for capturing player inputs
        input = new Custominput();

        // Get the Rigidbody2D component attached to the player object
        rb = GetComponent<Rigidbody2D>();

        // Reference to the main camera to define the boundaries
        mainCamera = Camera.main;

        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        // Enable the input system so it can start receiving inputs
        input.Enable();

        // Subscribe to the "performed" event, which triggers when movement input is provided
        input.Player.Movement.performed += OnMovementPerformed;

        // Subscribe to the "canceled" event, which triggers when movement input is stopped
        input.Player.Movement.canceled += OnMovementCancelled;
    }

    private void OnDisable()
    {
        // Disable the input system to stop receiving inputs
        input.Disable();

        // Unsubscribe from the "performed" event to avoid unintended behavior when disabled
        input.Player.Movement.performed -= OnMovementPerformed;

        // Unsubscribe from the "canceled" event to clean up event handlers
        input.Player.Movement.canceled -= OnMovementCancelled;
    }

    // This function is called when the player provides movement input (e.g., pressing arrow keys or joystick)
    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        // Read the Vector2 input from the player and store it in moveVector
        moveVector = value.ReadValue<Vector2>();

        if (moveVector.x > 0)
        {
            transform.localScale =  Vector3.one;

        }
        else
        {
            transform.localScale = new Vector3(-1f,1f,1f);
        }
        animator.SetBool("IsWalkingRight", true);
    }

    // FixedUpdate is called on a fixed time interval, typically used for physics-related updates
    private void FixedUpdate()
    {
        // Calculate the new velocity based on the input and movement speed
        rb.velocity = moveVector * moveSpeed;

        // After movement, clamp the player's position to keep them on screen
        ClampPosition();
    }

    // This function is called when the player stops providing movement input (e.g., releasing arrow keys or joystick)
    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        // Reset moveVector to zero, stopping the player's movement
        moveVector = Vector2.zero;
        animator.SetBool("IsWalkingRight", false);

    }

    // Method to clamp the player's position within the screen boundaries
    private void ClampPosition()
    {
        // Get the screen bounds in world coordinates based on the camera
        Vector3 minScreenBounds = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxScreenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        // Get the player's current position
        Vector3 playerPosition = transform.position;

        // Clamp the player's position within the screen boundaries
        playerPosition.x = Mathf.Clamp(playerPosition.x, minScreenBounds.x, maxScreenBounds.x);
        playerPosition.y = Mathf.Clamp(playerPosition.y, minScreenBounds.y, maxScreenBounds.y);

        // Apply the clamped position to the player
        transform.position = playerPosition;
    }
}
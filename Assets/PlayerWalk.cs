using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    public float moveSpeed = 5f; // Player movement speed
    public AudioSource movementAudioSource; // The AudioSource for movement sounds

    private Rigidbody2D rb; // Reference to Rigidbody2D
    private Vector2 movement; // Store movement direction

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get Rigidbody2D component
    }

    void Update()
    {
        // Get input from horizontal axis (left/right arrow or A/D keys)
        movement.x = Input.GetAxis("Horizontal");

        // Play sound if moving, stop if not
        if (movement.x != 0) // Player is moving
        {
            if (!movementAudioSource.isPlaying)
            {
                movementAudioSource.Play(); // Play sound
            }
        }
        else // Player is not moving
        {
            if (movementAudioSource.isPlaying)
            {
                movementAudioSource.Stop(); // Stop sound
            }
        }
    }

    void FixedUpdate()
    {
        // Move the player based on input
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

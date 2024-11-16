using UnityEngine;

public class Pencil_Script : MonoBehaviour
{
    [SerializeField]
    private float minSpeed = 19.0f; // Minimum speed for the item
    [SerializeField]
    private float maxSpeed = 20.0f; // Maximum speed for the item
    private float speed; // Actual speed of this specific item

    [SerializeField]
    private float _lifetime = 10.0f; // Lifetime for each pencil

    private void Start()
    {
        // Assign a random speed within the specified range
        speed = Random.Range(minSpeed, maxSpeed);

        // Destroy pencil after its lifetime expires
        Destroy(gameObject, _lifetime);
    }

    private void Update()
    {
        // Move the pencil downwards at its specific speed
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -5f)
        {
            ResetPosition(); // Reset the position if it goes out of bounds
        }
    }

    private void ResetPosition()
    {
        // Move the pencil to a random position at the top of the screen
        float randomX = Random.Range(-8f, 8f);
        transform.position = new Vector3(randomX, 7, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the pencil collides with the player
        if (other.CompareTag("Player"))
        {
            // Access PlayerMove component on the player to increase points
            PlayerMove playerMove = other.GetComponent<PlayerMove>();
            if (playerMove != null)
            {
                playerMove.PlayerPoints(); // Increase points
            }

            Destroy(this.gameObject); // Destroy the pencil after it's collected
        }
    }
}

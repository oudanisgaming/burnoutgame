using UnityEngine;

public class InfiniteWalk : MonoBehaviour
{
    public float speed = 5f; // Speed of the player movement
    private float screenRightEdge;
    private float screenLeftEdge;

    void Start()
    {
        // Get screen boundaries in world units
        screenRightEdge = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        screenLeftEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
    }

    void Update()
    {
        // Move the player to the right continuously
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // Check if the player has crossed the right edge of the screen
        if (transform.position.x > screenRightEdge)
        {
            // Move player back to the left edge of the screen
            Vector3 newPosition = transform.position;
            newPosition.x = screenLeftEdge;
            transform.position = newPosition;
        }
    }
}

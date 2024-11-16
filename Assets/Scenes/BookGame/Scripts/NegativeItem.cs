using UnityEngine;

public class NegativeItem : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.5f;

    void Update()
    {
        // Move the negative item downwards
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        // Reset position if it goes off-screen
        if (transform.position.y < -5f)
        {
            ResetPosition();
        }
    }

    void ResetPosition()
    {
        float randomX = Random.Range(-8f, 8f);
        transform.position = new Vector3(randomX, 7, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Call the Player's DecreasePoints method to reduce points
            other.GetComponent<PlayerMove>().DecreasePoints();
            Destroy(this.gameObject);
        }
    }
}

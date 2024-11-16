using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScroll : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = 30f; // Speed at which the text scrolls

    [SerializeField]
    private float disappearHeight = 0.1f; // Set the y-position where text should disappear


    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Move the text upwards
        rectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

        // Check if the text has reached the specified disappear height
        if (rectTransform.anchoredPosition.y >= disappearHeight)
        {
            gameObject.SetActive(false); // Hide the text

           
        }
    }
}
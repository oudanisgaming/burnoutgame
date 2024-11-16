using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomInteractionDirect : MonoBehaviour
{
    public GameObject bed;         // Reference to the Bed GameObject
    public GameObject table;       // Reference to the Table GameObject

    private bool tableClicked = false;   // Tracks if the Table has been clicked

    private void Start()
    {
        // Load previous tableClicked state if needed
        tableClicked = PlayerPrefs.GetInt("TableClicked", 0) == 1;

        // Disable table collider if it has already been clicked
        if (tableClicked && table != null)
        {
            table.GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnMouseDown()
    {
        // Detect if the click is on the Bed
        if (gameObject == bed)
        {
            HandleBedClick();
        }
        // Detect if the click is on the Table
        else if (gameObject == table)
        {
            HandleTableClick();
        }
    }

    private void HandleTableClick()
    {
        if (!tableClicked)
        {
            tableClicked = true;
            PlayerPrefs.SetInt("TableClicked", 1); // Save state
            SceneManager.LoadScene("minigames_table");   // Replace with your scene name
        }
    }

    private void HandleBedClick()
    {
        if (!tableClicked)
        {
            SceneManager.LoadScene("Game_Over");  // Replace with your Game_Over scene name
        }
        else
        {
            SceneManager.LoadScene("Next_Level"); // Replace with your next_level scene name
        }
    }
}

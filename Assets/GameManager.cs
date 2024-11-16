using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool playerWon = false;
    public float timeLimit = 180f; // Time limit for mini-games (3 minutes)

    private void Awake()
    {
        // Singleton pattern to persist GameManager across scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetWinStatus(bool won)
    {
        playerWon = won;
        ShowResultMessage();
    }

    private void ShowResultMessage()
    {
        // Load the result scene to show win/lose message
        SceneManager.LoadScene("ResultScene");
    }
}

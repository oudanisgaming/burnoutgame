/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StressBarManager : MonoBehaviour
{
    // public static StressBarManager Instance;
    public static StressBarManager Instance { get; private set; }

    // References
    [SerializeField] private Slider stressBar; // The slider for the stress bar
    [SerializeField] private float totalStressTime = 120f; // Total time for the stress bar (2 minutes)
    private float stressTimeLeft;
    private HashSet<string> completedMiniGames = new HashSet<string>(); // Track completed mini-games
    public int totalMiniGames = 4; // Set this to the actual number of mini-games in your game
   

    private void Awake()
    {
       /* // Ensure there is only one instance of StressBarManager
        //if (Instance != null && Instance != this)
        //{
          //  Destroy(gameObject); // Destroy any extra instances
        //}
       // else
       // {
          //  Instance = this; // Set the singleton instance
          //  DontDestroyOnLoad(gameObject); // Optional: Keeps this object when changing scenes
       // }
         // Singleton setup
         if (Instance == null)
         {
             Instance = this;

            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;

        }
        else
         {
             Destroy(gameObject);
            return;
         }
    }

    private void Start()
    {
        stressTimeLeft = totalStressTime; // Start with full stress time
        if (stressBar != null)
        {
            stressBar.maxValue = totalStressTime;
            stressBar.value = stressTimeLeft;
        }
    }

    private void Update()
    {
        // Update stress time and check win/lose conditions
        if (stressTimeLeft > 0)
        {
            stressTimeLeft -= Time.deltaTime;
            if (stressBar != null)
            {
                stressBar.value = stressTimeLeft;
            }
        }
        else
        {
            if (stressBar != null)
            {
                stressBar.value = 0f;
                Lose(); // Trigger lose condition if stress bar is full
            }
        }

        // Check for win condition
        CheckForWin();
    }

    private void CheckForWin()
    {
        // Player wins if all mini-games are completed and stress bar is not full
        if (completedMiniGames.Count == totalMiniGames && stressTimeLeft > 0)
        {
            Win();
        }
    }

    private void Win()
    {
        // Trigger win logic, load the win scene
        SceneManager.LoadScene("Win_Scene"); // Replace with your actual win scene name
    }

    private void Lose()
    {
        // Trigger lose logic, load the lose scene
        SceneManager.LoadScene("Lose_Scene"); // Replace with your actual lose scene name
    }

    // This method should be called when a mini-game is completed
    public void CompletedMiniGame(string miniGameName)
    {
        if (!completedMiniGames.Contains(miniGameName))
        {
            completedMiniGames.Add(miniGameName);
        }

        // After every mini-game completion, check if win condition is met
        CheckForWin();
    }

    // Call this method to decrease the stress bar time
    public void DecreaseStress(float amount)
    {
        stressTimeLeft = Mathf.Max(0, stressTimeLeft - amount); // Ensure it doesn't go below 0
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        losePanel = GameObject.Find("loseMessage");
        Slider newStressBar = FindObjectOfType<Slider>();
        if (newStressBar != null && newStressBar != stressBar)
        {
            stressBar = newStressBar;
            stressBar.maxValue = stressDuration;
            stressBar.value = stressTimeLeft;
        }
    }
}*/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class StressBarManager : MonoBehaviour
{
    public static StressBarManager Instance;
    public Slider stressBar;
    public float stressDuration = 120f;
    public float stressTimeLeft;
    private HashSet<string> completedMiniGames = new HashSet<string>();

    [SerializeField]
    private GameObject losePanel;
    [SerializeField]
    private GameObject winPanel; // Add a win panel for displaying win message

    private bool allGamesCompleted = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        GameObject.Find("loseMessage")?.transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("winMessage")?.transform.GetChild(0).gameObject.SetActive(false);

        stressTimeLeft = stressDuration;
        if (stressBar != null)
        {
            stressBar.maxValue = stressDuration;
            stressBar.value = stressDuration;
        }
    }

    private void Update()
    {
        if (stressTimeLeft > 0)
        {
            stressTimeLeft -= Time.deltaTime;
            if (stressBar != null)
            {
                stressBar.value = stressTimeLeft;
            }
        }
        else
        {
            if (stressBar != null)
            {
                stressBar.value = 0f;
                Lose();
            }
        }

        // Check for win condition
        CheckForWin();
    }

    private void CheckForWin()
    {
        // Player wins if all mini-games are completed and stress bar is not full
        if (completedMiniGames.Count == 4 && stressTimeLeft > 0) // Assuming 4 is the total mini-games count
        {
            Win();
        }
    }

    public void CompletedMiniGame(string miniGameName)
    {
        if (!completedMiniGames.Contains(miniGameName))
        {
            completedMiniGames.Add(miniGameName);
        }
    }

    private void Lose()
    {
        if (!allGamesCompleted)
        {
            SceneManager.LoadScene("Game_Over");
        }
    }

    public void CompleteAllGames()
    {
        allGamesCompleted = true;
        CheckForWin(); // Check win condition when all games are completed
    }

    private void Win()
    {
        // Trigger win logic, show win message or load the win scene
        if (winPanel != null)
        {
            winPanel.SetActive(true); // Display win panel
        }
        else
        {
            SceneManager.LoadScene("Win_Scene"); // Replace with your actual win scene name
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        losePanel = GameObject.Find("loseMessage");
        winPanel = GameObject.Find("winMessage"); // Initialize win panel reference

        Slider newStressBar = FindObjectOfType<Slider>();
        if (newStressBar != null && newStressBar != stressBar)
        {
            stressBar = newStressBar;
            stressBar.maxValue = stressDuration;
            stressBar.value = stressTimeLeft;
        }
    }
}

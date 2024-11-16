using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.SceneManagement;

public class Cup : MonoBehaviour, IDropHandler
{
    // Reference to the steam animation GameObject
    public GameObject steamAnimation;

    // Reference to the cup's Image component
    public SpriteRenderer cupImage;

    // Sprite to represent the filled cup
    public Sprite filledCupSprite;
    private pauseMenu pause_menu;


    private bool isFilled = false; // Track if the cup is filled

    private void Start()
    {
        pause_menu = FindObjectOfType<pauseMenu>();
        // Ensure the steam animation is inactive at the start
        if (steamAnimation != null)
        {
            steamAnimation.SetActive(false);
        }
    }

    // Property to expose the `isFilled` status
    public bool IsFilled
    {
        get { return isFilled; }
    }

    // Implement the IDropHandler interface
    public void OnDrop(PointerEventData eventData)
    {
        // This method is required by IDropHandler but not used here
    }

    // Method to fill the cup
    public void FillCup()
    {
        if (pause_menu != null && pause_menu.IsPaused())
            return;
        if (!isFilled)
        {
            isFilled = true; // Mark the cup as filled
            Debug.Log("The cup is now filled with coffee.");

            // Change the cup image to the filled cup sprite
            // if (cupImage != null && filledCupSprite != null)
            // {
            //     cupImage.sprite = filledCupSprite;
            // }

            // Activate the steam animation
            if (steamAnimation != null)
            {
                steamAnimation.SetActive(true);
                // Optionally, start a coroutine to handle animation timing
                //StartCoroutine(DisableSteamAfterTime(4f));
            }
        }
        else
        {
            Debug.Log("The cup is already filled.");
        }
    }

    private IEnumerator DisableSteamAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        if (steamAnimation != null)
        {
            steamAnimation.SetActive(false);
        }
    }

    public void CloseCup()
    {
        if (pause_menu != null && pause_menu.IsPaused())
            return;
        steamAnimation.SetActive(false);
        cupImage.sprite = filledCupSprite;
        StartCoroutine(EndGame(2));

        // Notify the StressBarManager that this mini-game is complete
        if (StressBarManager.Instance != null)
        {
            // Add logic to track completed mini-games
            StressBarManager.Instance.CompletedMiniGame("CoffeeMakingGame");
        }

    }
    
    private IEnumerator EndGame(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("MainMenu");
    }

   
    
        
    
}

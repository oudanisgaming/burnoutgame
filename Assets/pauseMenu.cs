using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    [SerializeField]public GameObject Pause_Panel;
    [SerializeField]public GameObject Settings_Panel; // Reference to the settings panel

    private bool isPaused = false;

    void Start()
    {
        Pause_Panel.SetActive(false);
        Settings_Panel.SetActive(false); // Ensure settings panel is initially hidden
    }

    void Update()
    {
        // Ensure the game remains paused if either the pause or settings panel is active
        if (Pause_Panel.activeInHierarchy || Settings_Panel.activeInHierarchy)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; // Freeze time
        isPaused = true; // Update pause state
    }

    public void ResumeGame()
    {
        // Only resume the game if neither panel is active
        if (!Pause_Panel.activeInHierarchy && !Settings_Panel.activeInHierarchy)
        {
            Time.timeScale = 1f; // Resume time
            isPaused = false; // Update pause state
        }
    }

    public void ShowPausePanel()
    {
        Pause_Panel.SetActive(true); // Show the pause panel
    }

    public void HidePausePanel()
    {
        Pause_Panel.SetActive(false); // Hide the pause panel
    }

    public void ShowSettingsPanel()
    {
        Settings_Panel.SetActive(true); // Show the settings panel
    }

    public void HideSettingsPanel()
    {
        Settings_Panel.SetActive(false); // Hide the settings panel
    }

    public bool IsPaused()
    {
        return isPaused; // Return the current pause state
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickableObject : MonoBehaviour
{
    private bool isClickable = true;
    private pauseMenu pause_menu;
    private void Start()
    {

        pause_menu = FindObjectOfType<pauseMenu>();

    }
    private void OnMouseDown()
    {
        if (pause_menu != null && pause_menu.IsPaused())
            return;
        if (isClickable)
        {
            // Set the flag to indicate we are transitioning to another scene
            PlayerPrefs.SetInt("ReturningFromScene2", 1);

            // Load Scene2
            SceneManager.LoadScene("Loading_minigame_scene", LoadSceneMode.Additive); 
        }
    }

    public void SetClickable(bool clickable)
    {
        isClickable = clickable;
    }
}


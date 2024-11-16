using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickableObject_table : MonoBehaviour
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
            PlayerPrefs.SetInt("ReturningFromTable", 1);

            // Load Scene2
            SceneManager.LoadScene("minigames_table");
        }
    }

    public void SetClickable(bool clickable)
    {

        isClickable = clickable;
    }
}


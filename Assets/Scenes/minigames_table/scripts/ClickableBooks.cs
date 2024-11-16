using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickableBooks : MonoBehaviour
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
            PlayerPrefs.SetInt("ReturningFromSceneBooks", 1);

            // Load Scene
            SceneManager.LoadScene("Book_Game");
        }
    }

    public void SetClickable(bool clickable)
    {
 
        SceneManager.LoadScene("The_Room");
    }
}


using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickableObject_bed : MonoBehaviour
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
        if (PlayerPrefs.GetInt("ReturningFromBooks", 0) == 0)
        {
           
            SceneManager.LoadScene("Game_Over");
        }
        else if (PlayerPrefs.GetInt("ReturningFromBooks", 0) == 1)
        {
            SceneManager.LoadScene("Next_Level");
        }
    }

    public void SetClickable(bool clickable)
    {
      
            isClickable = clickable;
      
    }
   
}


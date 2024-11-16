using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickableCoffeeCup : MonoBehaviour
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
            PlayerPrefs.SetInt("ReturningFromCoffee", 1);


            // Load Scene2
 
            SceneManager.LoadScene("CoffeeMiniGameScene", LoadSceneMode.Additive); 
        }
    }

    public void SetClickable(bool clickable)
    {
        isClickable = clickable;
    }
}

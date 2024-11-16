using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu_Script : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Debug.Log("Exit Game!"); // a message in console
        Application.Quit();// it will quits the game when the player clicks on it
        UnityEditor.EditorApplication.isPlaying = false;// to stop the play mode
    }
    public void CreditsGame()
    {
        SceneManager.LoadScene(7);
    }
}

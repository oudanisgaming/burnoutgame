using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit_yes : MonoBehaviour
{
    // Start is called before the first frame update
    public void QuitGame()
    {
        Debug.Log("Exit Game!"); // a message in console
        Application.Quit();// it will quits the game when the player clicks on it
        UnityEditor.EditorApplication.isPlaying = false;// to stop the play mode
    }
}

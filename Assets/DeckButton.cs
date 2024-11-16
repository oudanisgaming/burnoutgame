using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeckButton : MonoBehaviour
{
    private pauseMenu pause_menu;

    private void Start()
    {

        pause_menu = FindObjectOfType<pauseMenu>();

    }
    // Start is called before the first frame update
    public void PlayGame()
    {
        if (pause_menu != null && pause_menu.IsPaused())
            return;
        SceneManager.LoadSceneAsync(4);
    }

    // Update is called once per frame

}

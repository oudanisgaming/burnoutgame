using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSound : MonoBehaviour
{
    private AudioManager audioManager;

    private void Start()
    {
        // Attempt to find the AudioManager at the start of the game
        GameObject audioObject = GameObject.FindGameObjectWithTag("Audio");

        if (audioObject != null)
        {
            audioManager = audioObject.GetComponent<AudioManager>();
            if (audioManager == null)
            {
                Debug.LogError("AudioManager component not found on GameObject tagged 'Audio'!");
            }
        }
        else
        {
            Debug.LogError("No GameObject with tag 'Audio' found in the scene!");
        }
    }

    public void Lose()
    {
        // Check if audioManager is available before calling MusicStart
        if (audioManager == null)
        {
            Debug.LogError("AudioManager is not set up correctly. Unable to play game-over sound!");
            return;
        }

        // Play the game-over sound
        if (audioManager.gameOver != null)
        {
            audioManager.MusicStart(audioManager.gameOver);
        }
        else
        {
            Debug.LogError("Game-over audio clip is not assigned in AudioManager!");
        }
    }
}

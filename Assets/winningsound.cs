using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningSound : MonoBehaviour
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

    public void Win()
    {
        // Check if audioManager is available before calling MusicStart
        if (audioManager == null)
        {
            Debug.LogError("AudioManager is not set up correctly. Unable to play winning sound!");
            return;
        }

        // Play the winning sound
        if (audioManager.winning != null)
        {
            audioManager.MusicStart(audioManager.winning);
        }
        else
        {
            Debug.LogError("Winning audio clip is not assigned in AudioManager!");
        }
    }
}

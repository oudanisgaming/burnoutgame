using UnityEngine;

public class PlaySoundOnClick : MonoBehaviour
{
    public AudioSource audioSource;  // Reference to the AudioSource component

    public void PlaySound() 
    {
        audioSource.Play();  // Play the sound when this function is called
    }
}

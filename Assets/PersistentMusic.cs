using UnityEngine;

public class PersistentMusic : MonoBehaviour
{
    private static PersistentMusic instance = null;
    private AudioSource musicSource;

    void Awake()
    {
        // Check if there's already an instance of this music object
        if (instance == null)
        {
            instance = this;
           // DontDestroyOnLoad(this.gameObject);
            musicSource = GetComponent<AudioSource>(); // Get the AudioSource component
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to stop the music
    public void StopMusic()
    {
        if (musicSource != null)
        {
            musicSource.Stop();
        }
    }
}

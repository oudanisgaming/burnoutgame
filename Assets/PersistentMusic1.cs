using UnityEngine;

public class PersistentMusic1 : MonoBehaviour
{
    private static PersistentMusic1 instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Keep the music playing across scenes
            GetComponent<AudioSource>().Play(); // Start the music
        }
        else
        {
            Destroy(gameObject);  // Destroy duplicate music objects in other scenes
        }
    }

    public void StopMusic()
    {
        GetComponent<AudioSource>().Stop();
    }
}

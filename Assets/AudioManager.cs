using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------ Audio Source ------")]
    [SerializeField] private AudioSource musicSource; // Ensure this is assigned in the Inspector.

    [Header("------ Audio Clips ------")]
    public AudioClip winning;
    public AudioClip gameOver;

    private void Start()
    {
        // Optional: Check if musicSource is properly assigned.
        if (musicSource == null)
        {
            Debug.LogError("MusicSource is not assigned in AudioManager!");
        }
    }

    public void MusicStart(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogError("No audio clip provided to MusicStart!");
            return;
        }

        if (musicSource == null)
        {
            Debug.LogError("MusicSource is not assigned in AudioManager!");
            return;
        }

        musicSource.PlayOneShot(clip);
    }
}



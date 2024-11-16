using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOverlayManager : MonoBehaviour
{
    public void ShowOverlayScene()
    {
        // Load the overlay scene without unloading the current scene
        SceneManager.LoadScene("OverlayScene", LoadSceneMode.Additive);
    }

    public void HideOverlayScene()
    {
        // Unload the overlay scene when done
        SceneManager.UnloadSceneAsync("OverlayScene");
    }
}

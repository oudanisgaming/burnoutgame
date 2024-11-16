using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectClickManager : MonoBehaviour
{
    public GameObject screenHeart;
    public GameObject closeCup;

    private void Start()
    {
        // Make sure both objects are clickable at the start
        screenHeart.GetComponent<Collider2D>().enabled = true;
        closeCup.GetComponent<Collider2D>().enabled = true;
    }

    public void OnScreenHeartClick()
    {
        // Disable further clicks on the screen_heart
        screenHeart.GetComponent<Collider2D>().enabled = false;

        // Load the scene for screen_heart
        SceneManager.LoadScene("Loading_minigame_scene");
    }

    public void OnCloseCupClick()
    {
        // Disable further clicks on closeCup and screen_heart
        closeCup.GetComponent<Collider2D>().enabled = false;
        screenHeart.GetComponent<Collider2D>().enabled = false;

        // Load the scene for closeCup
        SceneManager.LoadScene("CoffeeMiniGameScene");
    }

    // This will be called when you return to the minigames_table scene
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "minigames_table")
        {
            // Disable the objects from being clicked after returning
            screenHeart.GetComponent<Collider2D>().enabled = false;
            closeCup.GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

using UnityEngine;


public class SceneController : MonoBehaviour
{
    public ClickableObject clickableObject; // Reference to the ClickableObject script
    public GameObject Screen_heart_outline1;
    public GameObject Screen_heart_outline2;
    public GameObject Screen_heart_outline3;
    public GameObject Screen_heart_outline4;


    private void Start()
    {
        // Check if returning from another scene
        if (PlayerPrefs.GetInt("ReturningFromScene2", 0) == 1)
        {
            // Make the object non-clickable
            clickableObject.SetClickable(false);

            // Reset the flag so it doesn't stay active
            PlayerPrefs.SetInt("ReturningFromScene2", 0);

            //Destroy outlines
            Screen_heart_outline1.SetActive(false);
            Screen_heart_outline2.SetActive(false);
            Screen_heart_outline3.SetActive(false);
            Screen_heart_outline4.SetActive(false);
        }
        else
        {
            // If not returning, keep the object clickable
            clickableObject.SetClickable(true);
        }
    }
}


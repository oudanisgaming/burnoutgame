using UnityEngine;

public class SceneController_table : MonoBehaviour
{
    public ClickableObject_table ClickableObject_table; // Reference to the ClickableObject_table script

    // Table outlines
    public GameObject Table1_outline1;
    public GameObject Table1_outline2;
    public GameObject Table1_outline3;
    public GameObject Table1_outline4;

    // Mouse outline
    public GameObject Mouse_outline;

    // Screen heart outlines
    public GameObject Screen_heart_outline1;
    public GameObject Screen_heart_outline2;
    public GameObject Screen_heart_outline3;
    public GameObject Screen_heart_outline4;

    // ClosedCup outlines
    public GameObject ClosedCup_outline1;
    public GameObject ClosedCup_outline2;
    public GameObject ClosedCup_outline3;

    private void Start()
    {
        // Check if returning from another scene
        if (PlayerPrefs.GetInt("ReturningFromTable", 0) == 1)
        {
            // Make the object non-clickable
            ClickableObject_table.SetClickable(false);

            // Reset the flag so it doesn't stay active
            PlayerPrefs.SetInt("ReturningFromTable", 0);

            // Deactivate all outlines

            // Table outlines
            Table1_outline1.SetActive(false);
            Table1_outline2.SetActive(false);
            Table1_outline3.SetActive(false);
            Table1_outline4.SetActive(false);

            // Mouse outline
            Mouse_outline.SetActive(false);

            // Screen heart outlines
            Screen_heart_outline1.SetActive(false);
            Screen_heart_outline2.SetActive(false);
            Screen_heart_outline3.SetActive(false);
            Screen_heart_outline4.SetActive(false);

            // ClosedCup outlines
            ClosedCup_outline1.SetActive(false);
            ClosedCup_outline2.SetActive(false);
            ClosedCup_outline3.SetActive(false);
        }
        else
        {
            // If not returning, keep the object clickable
            ClickableObject_table.SetClickable(true);
        }
    }
}

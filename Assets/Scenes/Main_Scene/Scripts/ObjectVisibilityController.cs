using UnityEngine;

public class ObjectVisibilityController : MonoBehaviour
{
    public GameObject Table1_outline1;
    public GameObject Table1_outline2;
    public GameObject Table1_outline3;
    public GameObject Table1_outline4;

    public GameObject Mouse_outline;

    public GameObject Screen_heart_outline1;
    public GameObject Screen_heart_outline2;
    public GameObject Screen_heart_outline3;
    public GameObject Screen_heart_outline4;

    public GameObject ClosedCup_outline1;
    public GameObject ClosedCup_outline2;
    public GameObject ClosedCup_outline3;

    public GameObject Bed_outline1;
    public GameObject Bed_outline2;
    public GameObject Bed_outline3;
    public GameObject Bed_outline4; // Reference to the object you want to appear or disappear

    // Method to make the object appear
    public void ShowObjectTable()
    {
        // This will make the object appear
        Table1_outline1.SetActive(true);
        Table1_outline2.SetActive(true);
        Table1_outline3.SetActive(true);
        Table1_outline4.SetActive(true);
        Mouse_outline.SetActive(true);
        Screen_heart_outline1.SetActive(true);
        Screen_heart_outline2.SetActive(true);
        Screen_heart_outline3.SetActive(true);
        Screen_heart_outline4.SetActive(true);
        Mouse_outline.SetActive(true);
        ClosedCup_outline1.SetActive(true);
        ClosedCup_outline2.SetActive(true);
        ClosedCup_outline3.SetActive(true);
    }

    public void ShowObjectBed()
    {
        // This will make the object appear
        Bed_outline1.SetActive(true);
        Bed_outline2.SetActive(true);
        Bed_outline3.SetActive(true);
        Bed_outline4.SetActive(true);
    }

    // Method to make the object disappear
    public void HideObjectTable()
    {
        Table1_outline1.SetActive(false);
        Table1_outline2.SetActive(false);
        Table1_outline3.SetActive(false);
        Table1_outline4.SetActive(false);
        Mouse_outline.SetActive(false);
        Screen_heart_outline1.SetActive(false);
        Screen_heart_outline2.SetActive(false);
        Screen_heart_outline3.SetActive(false);
        Screen_heart_outline4.SetActive(false); 
        ClosedCup_outline1.SetActive(false);
        ClosedCup_outline2.SetActive(false);
        ClosedCup_outline3.SetActive(false); // This will make the object disappear
    }

    public void HideObjectBed()
    {
        Bed_outline1.SetActive(false);  // Corrected to SetActive(false)
        Bed_outline2.SetActive(false);  // Corrected to SetActive(false)
        Bed_outline3.SetActive(false);  // Corrected to SetActive(false)
        Bed_outline4.SetActive(false);  // Corrected to SetActive(false)
    }

    void Start()
    {
        Bed_outline1.SetActive(false);  // Corrected to SetActive(false)
        Bed_outline2.SetActive(false);  // Corrected to SetActive(false)
        Bed_outline3.SetActive(false);  // Corrected to SetActive(false)
        Bed_outline4.SetActive(false);  // Corrected to SetActive(false)

        // Optionally, you can start with the object hidden
        Table1_outline1.SetActive(false);
        Table1_outline2.SetActive(false);
        Table1_outline3.SetActive(false);
        Table1_outline4.SetActive(false);
        Mouse_outline.SetActive(false);
        Screen_heart_outline1.SetActive(false);
        Screen_heart_outline2.SetActive(false);
        Screen_heart_outline3.SetActive(false);
        Screen_heart_outline4.SetActive(false);
        ClosedCup_outline1.SetActive(false);
        ClosedCup_outline2.SetActive(false);
        ClosedCup_outline3.SetActive(false);
        
    }

    // Example: If you want to toggle object visibility based on user input
    void Update()
    {
        if (transform.position.x >= 2.55)
        {
            ShowObjectTable();
        }
        else if (transform.position.x <= -0.84)
        {
            ShowObjectBed();
        }
        else
        {
            HideObjectTable();
            HideObjectBed();
        }
    }
}

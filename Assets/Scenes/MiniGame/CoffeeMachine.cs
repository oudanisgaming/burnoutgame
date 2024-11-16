using UnityEngine;

public class CoffeeMachine : MonoBehaviour
{
    public CoffeePot coffeePot; // Reference to the CoffeePot script
    private pauseMenu pause_menu;
    private void Start()
    {
        pause_menu = FindObjectOfType<pauseMenu>();
        // Ensure the CoffeePot reference is assigned
        if (coffeePot == null)
        {
            coffeePot = FindObjectOfType<CoffeePot>();
            if (coffeePot == null)
            {
                Debug.LogError("CoffeePot script not found in the scene.");
            }
        }
    }

    // This method will be called when beans are added to the machine
    public void AddBeans()
    {
        if (pause_menu != null && pause_menu.IsPaused())
            return;
        Debug.Log("Beans added to the machine.");

        // Notify the CoffeePot that beans have been added
        if (coffeePot != null)
        {
            Debug.Log("Calling coffeePot.BeansAdded()");
            // coffeePot.BeansAdded();
        }
        else
        {
            Debug.LogError("coffeePot reference is null in CoffeeMachine.");
        }
    }

    // Detect when beans enter the machine's trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.CompareTag("Beans"))
        // {
        //     Debug.Log("Beans have entered the coffee machine trigger.");
        //     AddBeans();

        //     // Optionally destroy the beans object after adding
        //     Destroy(collision.gameObject);
        // }
    }
}
// using UnityEngine;
// using UnityEngine.UI;

// public class CoffeePot : MonoBehaviour
// {
//     // Image GameObjects representing different fill levels
//     public GameObject EmptyCoffeePot;
//     public GameObject LittleCoffeePot;
//     public GameObject HalfCoffeePot;
//     public GameObject FullCoffeePot;

//     // UI Text for displaying messages to the player
//     public Text fillMessage;

//     // Internal state variables
//     private int fillLevel = 0;       // Fill levels: 0 = empty, 1 = little, 2 = half, 3 = full
//     private bool beansAdded = false; // Tracks if beans have been added to the machine

//     private void Start()
//     {
//         Debug.Log("Starting CoffeePot with fill level: " + fillLevel);

//         // Ensure all images are assigned
//         if (EmptyCoffeePot == null || LittleCoffeePot == null || HalfCoffeePot == null || FullCoffeePot == null)
//         {
//             Debug.LogError("One or more CoffeePot images are not assigned in the Inspector!");
//         }

//         // Initialize the coffee pot's visual state and message
//         UpdateCoffeePotState();
//         DisplayFillMessage();
//     }

//     private void Update()
//     {
//         // Detect left mouse button click
//         if (Input.GetMouseButtonDown(0))
//         {
//             // Convert mouse position to world coordinates (for 2D)
//             Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//             // Perform a raycast at the mouse position
//             RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

//             // Check if the coffee pot was clicked
//             if (hit.collider != null && hit.collider.gameObject == this.gameObject)
//             {
//                 Debug.Log("Mouse clicked on the coffee pot.");
//                 FillPot();
//             }
//             else
//             {
//                 Debug.Log("Mouse click did not hit the coffee pot.");
//             }
//         }

//         // For debugging: increment fill level with the Space key
//         if (Input.GetKeyDown(KeyCode.Space))
//         {
//             FillPot();
//         }
//     }

//     // Returns true if the coffee pot is full
//     public bool IsFull()
//     {
//         return fillLevel == 3;
//     }

//     // Method to fill the coffee pot
//     public void FillPot()
//     {
//         Debug.Log("Before Fill: Current fill level is: " + fillLevel + ", beansAdded is: " + beansAdded);

//         if (fillLevel < 3)
//         {
//             // Allow filling from empty to little fill without beans
//             if (fillLevel == 0)
//             {
//                 fillLevel++;
//                 Debug.Log("After Fill: New fill level is: " + fillLevel);
//                 UpdateCoffeePotState();
//                 DisplayFillMessage();
//             }
//             // Allow further filling only if beans have been added
//             else if (beansAdded)
//             {
//                 fillLevel++;
//                 Debug.Log("After Fill: New fill level is: " + fillLevel);
//                 UpdateCoffeePotState();
//                 DisplayFillMessage();
//             }
//             else
//             {
//                 // Inform the player to add beans
//                 Debug.Log("Cannot fill further until beans are added.");
//                 if (fillMessage != null)
//                 {
//                     fillMessage.text = "Add beans to the machine to continue filling the pot.";
//                 }
//             }
//         }
//         else
//         {
//             Debug.Log("The coffee pot is already full.");
//         }
//     }

//     // Method to empty the coffee pot
//     public void EmptyPot()
//     {
//         fillLevel = 0;
//         beansAdded = false; // Reset beansAdded when the pot is emptied
//         Debug.Log("Emptying the pot.");
//         UpdateCoffeePotState();
//         DisplayFillMessage();
//     }

//     // Method to be called when beans are added to the machine
//     public void BeansAdded()
//     {
//         beansAdded = true;
//         Debug.Log("Beans have been added to the machine. beansAdded set to true.");
//     }

//     // Updates the visual state of the coffee pot
//     private void UpdateCoffeePotState()
//     {
//         Debug.Log("Updating coffee pot state. Current fill level is: " + fillLevel);

//         // Disable all coffee pot images
//         EmptyCoffeePot.SetActive(false);
//         LittleCoffeePot.SetActive(false);
//         HalfCoffeePot.SetActive(false);
//         FullCoffeePot.SetActive(false);

//         // Activate the correct image based on the current fill level
//         switch (fillLevel)
//         {
//             case 0:
//                 Debug.Log("Showing Empty Coffee Pot");
//                 EmptyCoffeePot.SetActive(true);
//                 break;
//             case 1:
//                 Debug.Log("Showing Little Coffee Pot");
//                 LittleCoffeePot.SetActive(true);
//                 break;
//             case 2:
//                 Debug.Log("Showing Half Coffee Pot");
//                 HalfCoffeePot.SetActive(true);
//                 break;
//             case 3:
//                 Debug.Log("Showing Full Coffee Pot");
//                 FullCoffeePot.SetActive(true);
//                 break;
//             default:
//                 Debug.LogError("Invalid fill level.");
//                 break;
//         }
//     }

//     // Displays messages to the player based on the fill level
//     private void DisplayFillMessage()
//     {
//         if (fillMessage != null)
//         {
//             switch (fillLevel)
//             {
//                 case 0:
//                     fillMessage.text = "Pot is empty. Click the pot to start filling!";
//                     break;
//                 case 1:
//                     if (!beansAdded)
//                         fillMessage.text = "Add beans to the machine to continue filling the pot.";
//                     else
//                         fillMessage.text = "Pot is partially filled. Keep clicking!";
//                     break;
//                 case 2:
//                     fillMessage.text = "Pot is half-filled. Almost there!";
//                     break;
//                 case 3:
//                     fillMessage.text = "Pot is full! Drag to the cup to pour.";
//                     break;
//                 default:
//                     fillMessage.text = "";
//                     break;
//             }
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CoffeePot : MonoBehaviour//, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Image GameObjects for empty and full pot
    public GameObject EmptyCoffeePot;
    public GameObject FullCoffeePot;
    public SpriteRenderer coffeeImage;
    public Sprite emptyCoffeeSprite;
    public Animator coffeeAnimator;
    private pauseMenu pause_menu;

    // Sprite to represent the filled cup
    public Sprite filledCoffeeSprite;
    // UI Text for displaying messages
    public Text fillMessage;

    // Internal state variable
    private bool isFilled = false; // Tracks if the pot is filled

    public bool hasBeans;
    // Property to expose isFilled status
    public bool IsFilled
    {
        get { return isFilled; }
    }

    // Dragging variables
    private Vector3 originalPosition;
    //private CanvasGroup canvasGroup;

    private void Start()
    {
        pause_menu = FindObjectOfType<pauseMenu>();
        // Ensure images are assigned
        if (EmptyCoffeePot == null )//|| FullCoffeePot == null)
        {
            Debug.LogError("One or more CoffeePot images are not assigned in the Inspector!");
        }

        // Initialize visual state and message
        //UpdateCoffeePotState();
        DisplayFillMessage();

        // Store the original position
        originalPosition = transform.position;

        // Get or add CanvasGroup component
        //canvasGroup = GetComponent<CanvasGroup>();
        // if (canvasGroup == null)
        // {
        //     canvasGroup = gameObject.AddComponent<CanvasGroup>();
        // }
        // canvasGroup.blocksRaycasts = false; // Not draggable initially
    }

    private void Update()
    {
        if (pause_menu != null && pause_menu.IsPaused())
            return;
        // Detect left mouse button click
        if (Input.GetMouseButtonDown(0) && hasBeans)
        {
            // Convert mouse position to world coordinates
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Raycast at the mouse position
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            // Check if the coffee pot was clicked
            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                FillPot();
            }
        }
    }

    // Method to fill the coffee pot
    public void FillPot()
    {
        if (!isFilled)
        {
            isFilled = true;
            coffeeAnimator.enabled = true;
            StartCoroutine(DisableAnimationAfterFilled(0.92f));
            //UpdateCoffeePotState();
            //DisplayFillMessage();

            // Enable dragging
            //canvasGroup.blocksRaycasts = true;
        }
    }

    // Method to empty the coffee pot
    public void EmptyPot()
    {
        isFilled = false;
        UpdateCoffeePotState();
        DisplayFillMessage();
        hasBeans = false;
        // Reset position and disable dragging
        coffeeImage.sprite = emptyCoffeeSprite;
        transform.position = originalPosition;
        //canvasGroup.blocksRaycasts = false;
    }
    private IEnumerator DisableAnimationAfterFilled(float time)
    {
        yield return new WaitForSeconds(time);
        coffeeAnimator.enabled = false;
        // if (steamAnimation != null)
        // {
        //     steamAnimation.SetActive(false);
        // }
    }
    // Update the visual state of the coffee pot
    private void UpdateCoffeePotState()
    {
        // Disable both images
        EmptyCoffeePot.SetActive(false);
        FullCoffeePot.SetActive(false);

        // Activate the correct image
        if (!isFilled)
        {
            EmptyCoffeePot.SetActive(true);
        }
        else
        {
            FullCoffeePot.SetActive(true);
        }
    }

    // Display messages to the player
    private void DisplayFillMessage()
    {
        if (fillMessage != null)
        {
            if (!isFilled)
            {
                fillMessage.text = "Pot is empty. Click the pot to fill!";
            }
            else
            {
                fillMessage.text = "Pot is full! Drag to the cup to pour.";
            }
        }
    }

    // Drag handlers
    // public void OnBeginDrag(PointerEventData eventData)
    // {
    //     if (isFilled)
    //     {
    //         //canvasGroup.alpha = 0.6f; // Semi-transparent while dragging
    //         //canvasGroup.blocksRaycasts = false; // Allow drop detection
    //     }
    // }
    //
    // public void OnDrag(PointerEventData eventData)
    // {
    //     if (isFilled)
    //     {
    //         // Move the coffee pot with the cursor
    //         transform.position = Input.mousePosition;
    //     }
    // }
    //
    // public void OnEndDrag(PointerEventData eventData)
    // {
    //     if (isFilled)
    //     {
    //         //canvasGroup.alpha = 1f; // Reset transparency
    //         //canvasGroup.blocksRaycasts = true;
    //
    //         // Check if dropped over the cup
    //         if (eventData.pointerEnter != null && eventData.pointerEnter.CompareTag("Cup"))
    //         {
    //             // Get the Cup component and call FillCup()
    //             Cup cup = eventData.pointerEnter.GetComponent<Cup>();
    //             if (cup != null)
    //             {
    //                 cup.FillCup();
    //                 // Reset the coffee pot
    //                 EmptyPot();
    //             }
    //         }
    //         else
    //         {
    //             // Return to original position
    //             transform.position = originalPosition;
    //         }
    //     }
    // }
    private Vector3 offset;
    private bool isDragging = false;
    private void OnMouseDown()
    {
        if (!isFilled) return;
        // Capture the offset between mouse position and object position
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }
    private void OnMouseDrag()
    {
        if (!isFilled) return;
        if (isDragging)
        {
            // Move the object with the mouse
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            newPosition.z = 0; // Keep Z axis unchanged
            transform.position = newPosition;
        }
    }
    private void OnMouseUp()
    {
        if (!isFilled) return;
        isDragging = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cup"))
        {
            // Trigger the machine to show that coffee beans have been added
            other.GetComponent<Cup>().FillCup();
            EmptyPot();
            //Destroy(gameObject); // Remove the coffee beans from the scene
        }
    }
}






using UnityEngine;
using UnityEngine.UI;

public class CustomLoadBar : MonoBehaviour
{
    public Image loadBarFill;  // Reference to the Image component that fills the bar
    public float loadAmountPerPress = 0.05f;  // The amount the bar fills per space press
    public float unloadSpeed = 0.3f;  // The speed at which the bar decreases over time

    private float currentFillAmount = 0f;  // Tracks the current fill amount

    void Update()
    {
        // Increase the fill amount when the space button is pressed, but only if the bar is not full
        if (Input.GetKeyDown(KeyCode.Space) && currentFillAmount < 1f)
        {
            currentFillAmount += loadAmountPerPress;
        }

        // Decrease the fill amount over time when the space button is not pressed
        if (currentFillAmount > 0f && currentFillAmount < 1f)
        {
            currentFillAmount -= unloadSpeed * Time.deltaTime;
        }

        // Clamp the value between 0 and 1 to avoid overflow or underflow
        currentFillAmount = Mathf.Clamp(currentFillAmount, 0f, 1f);

        // Update the Image fillAmount property to visually represent the current fill level
        loadBarFill.fillAmount = currentFillAmount;
    }
}





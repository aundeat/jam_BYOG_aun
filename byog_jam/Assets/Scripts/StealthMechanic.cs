using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StealthMechanic : MonoBehaviour
{
    public Slider visibilitySlider; 
    public float maxVisibility = 100f; 
    public float visibilityIncreaseRate = 1f; 
    public float visibilityDecreaseRate = 0.5f;

    public float currentVisibility = 0f; 

    private void Start()
    {
        currentVisibility = 0f;
        UpdateVisibilityUI();
    }

    private void Update()
    {

        currentVisibility = Mathf.Clamp(currentVisibility, 0f, maxVisibility);

        UpdateVisibilityUI();

        if (currentVisibility >= maxVisibility)
        {
            GameOver();
        }
    }

    public void IncreaseVisibility(float amount)
    {
        currentVisibility += amount;
    }

    private void UpdateVisibilityUI()
    {
        if (visibilitySlider != null)
        {
            visibilitySlider.value = currentVisibility / maxVisibility;
        }
    }

    private void GameOver()
    {
        Debug.Log("Loser");
    }
}

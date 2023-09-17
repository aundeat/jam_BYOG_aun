using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StealthMechanic : MonoBehaviour
{
    public Slider visibilitySlider; 
    public float maxVisibility = 100f; 
    public float visibilityIncreaseRate = 1f; 
    public float visibilityDecreaseRate = 0.5f;
    private bool loser = false;

    public float currentVisibility = 0f;
    [SerializeField] private GameObject lostText;
    private void Start()
    {
        Time.timeScale = 1;
        maxVisibility = 100f;
        currentVisibility = 0f;
        UpdateVisibilityUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && loser == true)
        {
            RestartScene();
        }
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
        if(visibilitySlider.value >= 0.9f)
        {
            lostText.SetActive(true);
            loser = true;
        }
    }

    void RestartScene()
    {
        Time.timeScale = 1;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
      
    }
    void GameOver()
    {
        lostText.SetActive(true);
        loser = true;
        Time.timeScale = 0;
    }
}

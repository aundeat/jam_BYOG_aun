using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    public float visibilityIncreaseRate = 1f; 
    public float increaseInterval = 0.5f; 
    public float fastIncrease = 0.2f; 

    private StealthMechanic stealthMechanic;
    private float timer = 0f;
    private bool playerInside = false;

    private void Start()
    {
        stealthMechanic = FindObjectOfType<StealthMechanic>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= increaseInterval && stealthMechanic != null && playerInside)
        {
            stealthMechanic.IncreaseVisibility(visibilityIncreaseRate);
            visibilityIncreaseRate *= fastIncrease;
            timer = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            timer = 0f;
            visibilityIncreaseRate = 1f;
        }
    }
}

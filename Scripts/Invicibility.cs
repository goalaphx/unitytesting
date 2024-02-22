using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invicibility : MonoBehaviour
{
    public float powerUpDuration = 10f;
    // Audio clip to play when the power-up is collected


    // Reference to the audio source component
    [SerializeField] private AudioSource powerupsound;

    // Function to handle initialization
    private void Start()
    {
        // Get the AudioSource component attached to this GameObject
        powerupsound = GetComponent<AudioSource>();
        // Set the audio clip for the AudioSource
    
    }

    // Function to handle when something collides with the power-up
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Check if the object is the player
        {
            DestroyNearbyEnemies();
            powerupsound.Play();
            Destroy(gameObject);
         // Destroy the power-up after the player collects it
        }
    }

    // Function to destroy nearby enemies
    private void DestroyNearbyEnemies()
    {
        // Find all enemies in a certain radius of the player
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 5f); // Adjust the radius as needed

        // Loop through all colliders found
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy")) // Check if the collider is an enemy
            {
                // Destroy the enemy GameObject
                Destroy(collider.gameObject);
            }
        }
    }

    // Coroutine to destroy the power-up after a certain duration
    private IEnumerator DestroyPowerUpAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    // Start the coroutine when the power-up is enabled
    private void OnEnable()
    {
        StartCoroutine(DestroyPowerUpAfterDelay(powerUpDuration));
    }
}



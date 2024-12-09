using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public GameObject beePrefab;  // The prefab to instantiate
    public float respawnDelay = 2f; // The delay before respawn

    // Method to respawn the bee at a specific position
    public void RespawnBee(Vector2 spawnPosition)
    {
        StartCoroutine(RespawnAfterDelay(spawnPosition));
    }

    private IEnumerator RespawnAfterDelay(Vector2 spawnPosition)
    {
        Debug.Log("Waiting for respawn delay...");
        yield return new WaitForSeconds(respawnDelay);
        Debug.Log("Respawning bee...");
        GameObject newBee = Instantiate(beePrefab, spawnPosition, Quaternion.identity);
        
        // Ensure the newly instantiated bee is active
        newBee.SetActive(true);

        // Log to verify that the bee is active
        Debug.Log("Bee respawned and active: " + newBee.activeSelf);
    }
}
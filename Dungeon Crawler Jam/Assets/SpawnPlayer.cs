using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [HideInInspector]
    public Transform parentSpawnTransform = null; // To be filled with spawn positions from the first dungeon spawned.

    public GameObject levelGeneration;

    private Transform FindOpenSpawnPosition()
    {
        Transform spawnPosition = FindObjectOfType<SpawnFloor>().GetRandomSafeSpot();
        return spawnPosition ? spawnPosition : throw new System.Exception("No safe tiles");
        
        // No safe spot found - spawn at nearest entrace.
        
    }

    

    public void TranslatePlaterToSpawn() 
    {
        // Get the first room 
        parentSpawnTransform = levelGeneration.GetComponent<LevelGeneration>().firstRoom;
        Debug.Log(parentSpawnTransform);
        player.transform.position = FindOpenSpawnPosition() ? FindOpenSpawnPosition().position : new Vector3(0, 0, 0);
        player.transform.position = new Vector3(player.transform.position.x, 0.0f, player.transform.position.z);
    }
}

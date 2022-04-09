using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterGenerator : MonoBehaviour
{
    [SerializeField]
    private int DEFAULT_ENCOUNTER_THRESHOLD;
    [SerializeField]
    private int timerMin = 1;
    [SerializeField]
    private int timerMax = 30;
    [SerializeField]
    private int EncounterRate;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.tag == "Player")
        {
            CheckRandomEncounter();
        }
    }

    private void CheckRandomEncounter()
    {
        // Generate random number between two intervals 
        EncounterRate = Random.Range(timerMin, timerMax);

        // If random number is below the threshold - start encounter
        if(EncounterRate < DEFAULT_ENCOUNTER_THRESHOLD)
        {
            StartEncounter();
        }
    }

    private void StartEncounter()
    {
        Debug.Log("Starting encounter");
        // Pause time.delta time
        // Transition to Battle UI screen
    }
}

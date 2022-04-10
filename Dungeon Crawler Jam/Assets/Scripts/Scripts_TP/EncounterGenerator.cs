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

    private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            CheckRandomEncounter();
            player = other.gameObject;
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

        GameControl.control.StartBattleUI();
    }
}

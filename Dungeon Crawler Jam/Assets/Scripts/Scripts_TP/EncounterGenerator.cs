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

    [SerializeField, Tooltip("Level 1 encounter = 0 - 2, lvl 2 = 3 - 5, level 3 = 6 - 9")]
    private Monster[] encounterTable;

    [SerializeField]
    private AssignEnemy assignEnemy;

    private GameObject player;

    private void Awake()
    {
         
    }

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
        int rand;
        // Choose a monster to spawn
        switch (GameControl.control.currentLevel)
        {
            case 1:
                rand = Random.Range(0, 3);
                GameControl.control.SetCurrentEnemy(encounterTable[rand]);
                break;
            case 2:
                rand = Random.Range(3, 6);
                GameControl.control.SetCurrentEnemy(encounterTable[rand]);
                break;
            case 3:
                rand = Random.Range(6, 10);
                GameControl.control.SetCurrentEnemy(encounterTable[rand]);
                break;
            default:
                break;

        }
        //GameControl.control.StartBattleUI();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStairs : MonoBehaviour
{
    [SerializeField]
    private GameObject stairsUp;
    [SerializeField]
    private GameObject stairsDown;

    private Transform stairsUpPos, stairsDownPos;
    
    public void PlaceStairs()
    {
        FindOpenSpace();
        
        Debug.Log(stairsUpPos.position + " " + stairsDownPos.position);
        stairsUp.transform.position = stairsUpPos.position;
        stairsDown.transform.position = stairsDownPos.position;
        //stairsUp.transform.position = new Vector3 (0, 0, 0);
    }

    void FindOpenSpace()
    {
        // Go through the list of available floors.
        stairsUpPos = FindObjectOfType<SpawnFloor>().GetRandomSafeSpot();
        stairsDownPos = FindObjectOfType<SpawnFloor>().GetRandomEncounterSpot();
        // Place stairs
    }

}

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
        stairsUp.transform.position = stairsUpPos.position;
        stairsDown.transform.position = stairsDownPos.position;
    }

    void FindOpenSpace()
    {
        // Go through the list of available floors.
        stairsUpPos = FindObjectOfType<SpawnFloor>().GetRandomSafeSpot();
        stairsDownPos = FindObjectOfType<SpawnFloor>().GetRandomSafeSpot();
        // Place stairs
    }

}

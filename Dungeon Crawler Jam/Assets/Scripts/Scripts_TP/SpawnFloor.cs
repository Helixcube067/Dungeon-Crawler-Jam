using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum FloorType
{
    FloorEncounter = 0,
    FloorSafe = 1
};

enum SpawnShape
{
    Default,
    T, 
    Line,
    X
};

public class SpawnFloor : MonoBehaviour
{
    [SerializeField]
    private int numOfSafeTiles = 10;


    public GameObject[] floorTiles;
    // Start is called before the first frame update
    void Start()
    {
        ShapeToSpawn(SpawnShape.Default);
        // Instantiate Floors
        foreach(Transform child in transform)
        {
            if (child.tag == "FloorSafe")
            {
                GameObject instance = (GameObject)Instantiate(floorTiles[(int)FloorType.FloorSafe], child.transform.position, Quaternion.identity);
                instance.transform.parent = transform;
                
            }
            else if (child.tag == "FloorEncounter")
            {
                GameObject instance = (GameObject)Instantiate(floorTiles[(int)FloorType.FloorEncounter], child.transform.position, Quaternion.identity);
                instance.transform.parent = transform;
            }
                
        }
    }

    void ShapeToSpawn(SpawnShape shape)
    {
        int rand = Random.Range(0, floorTiles.Length);

        switch (shape)
        {
            case SpawnShape.T:

                break;
            case SpawnShape.Line:
                break;
            case SpawnShape.X:
                break;
            default:
                
                foreach (Transform child in transform)
                {
                    rand = Random.Range(0, 10);
                    child.tag = "FloorEncounter";
                    if (numOfSafeTiles > 0 && rand == 1)
                    {            
                        child.tag = "FloorSafe";
                        numOfSafeTiles--;
                    }
                }
                break;
        }
    }
}

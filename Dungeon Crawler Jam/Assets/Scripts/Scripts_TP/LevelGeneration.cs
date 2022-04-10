using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField, Tooltip("Array of northern most spawn positions")]
    private Transform[] startingPositions;

    [SerializeField, Tooltip("Array of all possible spawn positions")]
    private Transform[] allSpawnPositions;

    [SerializeField, Tooltip("indx 0 = North South, 1 = EWS, 2 = EWN, 3 = NWSE")]
    private GameObject[] dungeonRooms; // index 0 --> EW, index 1 --> EWS, index 2 --> EWN, index 3 --> NWES

    private int rand;
    
    [Header("Distance moved for each level DO NOT EDIT UNLESS SIZE OF LEVEL CHANGES")]
    [SerializeField]
    private float moveAmountX;
    [SerializeField]
    private float movementZ;

    // Cardinal direction var
    private int direction;

    // Timer vars spawning rooms
    private float timeBtwRoom;
    [SerializeField]
    private float startTimeBtwRoom = .25f;

    [SerializeField]
    private int minX;
    [SerializeField]
    private int maxX;
    [SerializeField]
    private int minZ;
    [SerializeField]
    private int maxZ;

    private bool stopGeneration = false;
    private bool canFill = false;
    private int randRoom;

    [SerializeField]
    private LayerMask roomMask;
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[rand].position;
        Instantiate(dungeonRooms[0], transform.position, Quaternion.identity);

        direction = Random.Range(1, 6);
    }
    private void Update()
    {
        if (!stopGeneration && timeBtwRoom <= 0)
        {
            Move();
            timeBtwRoom = startTimeBtwRoom;
        }
        else
        {
            timeBtwRoom -= Time.deltaTime;
        }

        // Only one time
        if(canFill)
        {
            FillLevl();
            canFill = false;
        }
            
    }
    // This logic spawns a path
    private void Move()
    {
        if(direction == 1 || direction == 2) // move RIGHT
        {
            if(transform.position.z < maxZ)
            {
                Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + movementZ);
                transform.position = newPos;

                randRoom = Random.Range(0, dungeonRooms.Length);

                Instantiate(dungeonRooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);
                if(direction == 3)
                {
                    direction = 2;
                    return;
                } 
                else if(direction == 4)
                {
                    direction = 5;
                    return;
                }
            }
            else
            {
                direction = 5;
            }

            

            return;
        } 
        else if(direction == 3 || direction == 4) // move LEFT
        {
            if (transform.position.z > minZ)
            {
                Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - movementZ);
                transform.position = newPos;

                direction = Random.Range(3, 6);

                randRoom = Random.Range(0, dungeonRooms.Length);
                Instantiate(dungeonRooms[randRoom], transform.position, Quaternion.identity);
            }
            else
            {
                direction = 5;
            }
            
            return;
        }
        else if(direction == 5) // move DOWN
        {
            if(transform.position.x < maxX)
            {
                Collider[] roomDetection = Physics.OverlapSphere(transform.position, 1, roomMask);
                foreach(Collider room in roomDetection)
                {
                    if(room.GetComponent<RoomType>())
                    {
                        if (room.GetComponent<RoomType>().GetTypeNum() != 1 && room.GetComponent<RoomType>().GetTypeNum() != 3)
                        {
                            room.GetComponent<RoomType>().RoomDestruction();

                            int randBottomRoom = Random.Range(1, 4);
                            if (randBottomRoom == 2)
                            {
                                randBottomRoom = 1;
                            }
                            Instantiate(dungeonRooms[randBottomRoom], transform.position, Quaternion.identity);

                        }
                    }
                }


                Vector3 newPos = new Vector3(transform.position.x - moveAmountX, transform.position.y, transform.position.z);
                transform.position = newPos;


                direction = Random.Range(1, 6);

                rand = Random.Range(2, 4); 

                Instantiate(dungeonRooms[rand], transform.position, Quaternion.identity);
            }
            else
            {
                // Stop Level Generation 
                
                stopGeneration = true;
                canFill = true;
            }
            
            return;
        }

        Debug.Log("instantiating at X = " + transform.position.x + " and Z = " + transform.position.z + " Direction = " + direction);
        
    }

    // Iterate through the remaining positions, check for a room there, if no room spawn a random one.
    private void FillLevl()
    {
        Debug.Log("Called fill");
        for(int i = 0; i < allSpawnPositions.Length; i++)
        {
            Debug.Log("i = " + i);
            Collider[] collider = Physics.OverlapSphere(allSpawnPositions[i].position, 1, roomMask);
            Debug.Log("collider length = " + collider.Length);
            foreach (Collider col in collider)
            {
                Debug.Log(col.name);
                if (!col)
                {
                    Instantiate(dungeonRooms[0], allSpawnPositions[i].position, Quaternion.identity);
                }
            }
        }
    }

}

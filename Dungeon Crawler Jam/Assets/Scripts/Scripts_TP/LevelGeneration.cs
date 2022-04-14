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

    private bool stopGeneration = true;
    private bool canFill = false;
    private int randRoom;

    [SerializeField]
    private LayerMask roomMask;

    [SerializeField]
    private SpawnPlayer spawnPlayer;

    [HideInInspector]
    public Transform firstRoom;
    


    // Start is called before the first frame update
    void Start()
    {
        //rand = Random.Range(0, startingPositions.Length);
        //transform.position = startingPositions[rand].position;
        //Instantiate(dungeonRooms[0], transform.position, Quaternion.identity);
        //// After the first space decided - provide transform to SpawnPlayer.
        //firstRoom = transform;
        //spawnPlayer.parentSpawnTransform = transform;
        //direction = Random.Range(1, 6);
        
    }

    public void GenerateLevel()
    {
        // Pick a random starting position for the dungeon room
        rand = Random.Range(0, startingPositions.Length);
        // Move this object to that position
        transform.position = startingPositions[rand].position;
        // Place room[0] at current location
        GameObject roomOne = Instantiate(dungeonRooms[0], transform.position, Quaternion.identity);
        // Assign the room to be the child of the level generator
        roomOne.transform.SetParent(transform);
        firstRoom = roomOne.transform;
        // Set first room to this room so spawnPlayer can find the first room.
        StartCoroutine("PlayerSetUp"); 

        // Set direction of next room 
        direction = Random.Range(1, 6);
        
        stopGeneration = false;
    }

    private IEnumerator PlayerSetUp()
    {
       yield return new WaitForSeconds(5);
       spawnPlayer.TranslatePlaterToSpawn();
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

                Debug.Log("Move right room spawned at " + transform.position);
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
                Debug.Log("Move left room spawned at " + transform.position);
                return;

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
                            Debug.Log("Move down room spawned at " + transform.position);


                        }
                    }
                }


                Vector3 newPos = new Vector3(transform.position.x - moveAmountX, transform.position.y, transform.position.z);
                transform.position = newPos;


                direction = Random.Range(1, 6);

                rand = Random.Range(2, 4); 


                Instantiate(dungeonRooms[rand], transform.position, Quaternion.identity);
                Debug.Log("Move Down 2 room spawned at " + transform.position);
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
        //Debug.Log("Called fill");

        //foreach(Vector3 positions in spawnPos)
        //{
        //    Debug.Log(transform.position);
        //}

        //for(int i = 0; i < allSpawnPositions.Length; i++)
        //{
        //    if(!spawnPos.Contains(allSpawnPositions[i].transform.position))
        //    {
        //        Debug.Log("spawning at " + allSpawnPositions[i]);
        //        Instantiate(dungeonRooms[0], allSpawnPositions[i].position, Quaternion.identity);
        //    }
        //}
    }

}
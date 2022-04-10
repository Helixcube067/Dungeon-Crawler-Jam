using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleToSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstacles;
    private void Awake()
    {
        int rand = Random.Range(0, obstacles.Length);
        foreach(Transform child in transform)
        {
            Debug.Log("Child names = " + child.name);
            Debug.Log("random name = " + obstacles[rand].name);
            if(child.gameObject == obstacles[rand].gameObject)
            {
                obstacles[rand].SetActive(true);
            }
        }
    }
}

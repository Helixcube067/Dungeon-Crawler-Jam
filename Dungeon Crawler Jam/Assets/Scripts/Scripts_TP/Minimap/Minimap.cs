using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player;
    private Vector3 newPos;
    // Update is called once per frame
    void LateUpdate()
    {
        newPos.x = player.position.x;
        newPos.y = transform.position.y;
        newPos.z = player.position.z;
        transform.position = newPos;
    }
}

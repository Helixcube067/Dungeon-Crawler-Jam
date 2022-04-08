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
        newPos.y = player.position.y;
        newPos.z = transform.position.z;
        transform.position = newPos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float rayLength = 1.4f;

    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private LayerMask stairLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Physics.Raycast(transform.position, transform.forward, rayLength))
        {
            if (Input.GetKeyDown(KeyCode.W))
                this.transform.position += transform.forward;
        }
        if(!Physics.Raycast(transform.position, -transform.forward, rayLength))
        {
            if (Input.GetKeyDown(KeyCode.S) && !Physics.Raycast(transform.position, -transform.forward, rayLength))
                this.transform.position += -transform.forward;
        }
        

        if (Input.GetKeyDown(KeyCode.A))
            this.transform.rotation *= Quaternion.Euler(0, -90, 0);
        else if (Input.GetKeyDown(KeyCode.D))
            this.transform.rotation *= Quaternion.Euler(0, 90, 0);

    }

    void DetectWall()
    {
        
    }
}

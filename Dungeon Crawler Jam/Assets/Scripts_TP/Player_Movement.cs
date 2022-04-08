using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            this.transform.position += transform.forward;
        else if (Input.GetKeyDown(KeyCode.S))
            this.transform.position += -transform.forward;
        else if (Input.GetKeyDown(KeyCode.A))
            this.transform.position += -transform.right;
        else if (Input.GetKeyDown(KeyCode.D))
            this.transform.position += transform.right;
        else if (Input.GetKeyDown(KeyCode.Q))
            this.transform.rotation *= Quaternion.Euler(0, -90, 0);
        else if (Input.GetKeyDown(KeyCode.E))
            this.transform.rotation *= Quaternion.Euler(0, 90, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    const int FORWARD = 1;
    const int BACKWARD = -1;

    [SerializeField] private float rayLength = 1.4f;

    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private LayerMask stairLayer;

    public bool inBattle = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //if (inBattle) return;

        if (DetectWall(FORWARD))
        {
            if (Input.GetKeyDown(KeyCode.W))
                this.transform.position += transform.forward;
        }
        if(DetectWall(BACKWARD))
        {
            if (Input.GetKeyDown(KeyCode.S))
                this.transform.position += -transform.forward;
        }
        if (Input.GetKeyDown(KeyCode.A))
            this.transform.rotation *= Quaternion.Euler(0, -90, 0);
        else if (Input.GetKeyDown(KeyCode.D))
            this.transform.rotation *= Quaternion.Euler(0, 90, 0);

    }

    // direction is either 1 for forward detection or -1 for backwards
    bool DetectWall(int direction)
    {
        if (!Physics.Raycast(transform.position, transform.forward * direction, rayLength)) return true;

        return false;
    }
}

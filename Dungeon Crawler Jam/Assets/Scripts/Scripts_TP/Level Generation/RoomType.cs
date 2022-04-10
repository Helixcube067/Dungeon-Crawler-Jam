using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomType : MonoBehaviour
{
    [SerializeField]
    private int type;

    public void RoomDestruction()
    {
        Destroy(gameObject);
    }

    public int GetTypeNum()
    {
        return type;
    }
}

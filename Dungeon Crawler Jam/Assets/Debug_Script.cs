using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_Script : MonoBehaviour
{
    public SceneMovement sceneMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            sceneMovement.LoadLevel("Level_Dungeon");
        }
    }

    public void ClickTest()
    {
        Debug.Log("I was clicked");
    }
}

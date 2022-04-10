using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneNames
{
    Prototype_Player_Movement,
    Scene_Transition1,
    Prototype_Interactables
};

public class GameControl : MonoBehaviour
{
    // Singleton design 
    public static GameControl control;

    // List of current player party members
    public List<GameObject> playerParty;

    [SerializeField]
    private GameLoss gameLossUI;

    [SerializeField]
    private SceneMovement sceneMovement;

    // private BattleUIClass battleUI;

    public int testNum = 10;
    
    void Awake()
    {
        // If there is no current gamecontrol 
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this; // This becomes the one variable to control everything
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }
        
    }

    public void GameOver()
    {
        if (gameLossUI == null) return;

            //Pause();
        Debug.Log("escape is pressed");
        gameLossUI.Setup();
        // Pause the game
        
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "testNum: " + testNum);
    }
}

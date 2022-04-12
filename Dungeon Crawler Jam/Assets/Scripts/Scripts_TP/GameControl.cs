using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    private GameObject battleUI;

    [SerializeField]
    private Player_Movement player;

    [SerializeField]
    private GameObject minimap;

    public int currentLevel = 1;

    public Monster currentEnemy;
    public AssignEnemy currentEnemyUI;

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

    public void SetCurrentEnemy(Monster newCurrent)
    {
        //currentEnemy.monsterPic = newCurrent.monsterPic;
        currentEnemy = newCurrent;
        if (!currentEnemyUI)
        {
            Debug.Log("CurrentEnemyUI is null");
        }
        else
            currentEnemyUI.SetEnemy(currentEnemy);

        StartBattleUI();
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

    public void LoadLevel(string scene)
    {
        sceneMovement.LoadLevel(scene);
    }

    public void StartBattleUI()
    {
        // Turn off Mini-Map
        minimap.SetActive(false);
        // Turn on Battle UI
        if (battleUI)
            battleUI.SetActive(true);
        else
            Debug.Log("BattleUI is null");
        // Stop Player movement
        player.inBattle = true;
    }

    public void StopBattleUI()
    {
        battleUI.SetActive(false);
        player.inBattle = false;
        minimap.SetActive(true);
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "testNum: " + testNum);
    }
}

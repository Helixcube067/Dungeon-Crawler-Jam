using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    private GameControl gameControl;
    #region battle handling
    public BattleState state;
    public TextMeshProUGUI mainNameText;
    public Monster playerMonster;
    public TextMeshProUGUI mainHPText;
    public Slider healthSlider;
    public AssignEnemy enemyGetter;
    //static monster here to load in with the information without it getting lost
    public static Monster enemyUnit;
    public TextMeshProUGUI statusUpdate;
    [SerializeField]
    SceneMovement sceneMover;
    #endregion
    #region level up info
    public GameObject levelupPanel;
    public GameObject battlePanel;
    public TextMeshProUGUI levelNameText;
    public TextMeshProUGUI levelMaxHpText;
    public TextMeshProUGUI levelAtkText;
    public TextMeshProUGUI levelDefText;
    public TextMeshProUGUI levelText;
    #endregion
    
    void Start()
    {
        
       

        if (!playerMonster)
            Debug.Log("No player monster found");

        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    void Update()
    {
        //mainNameText.text = playerMonster.name;
        //mainHPText.text = "HP: " + playerMonster.currHealth + "/" + playerMonster.maxHealth;
        //hpSlider.value = unit.currentHP;
    }

    //for when the encounter starts
    //update the UI here 
    IEnumerator SetupBattle()
    {
        //enemyHUD.SetHUD(enemyUnit)
        
        yield return new WaitForSeconds(2f);
        enemyUnit = enemyGetter.GetCurrentEnemy();
        if (!enemyUnit)
            Debug.Log("no enemy found");

        state = BattleState.PLAYERTURN;
        PlayerTurn();
        
    }

    void PlayerTurn() {
        statusUpdate.text = "Choose an action";
    }

    #region forget this for now
    /*void SetHP(int newValue) {
        hpSlider.value = PlayerStats.currHealth;
    }*/

    /*public void SetHUD(Monster monster) {
        //basically do UI updating here
    }*/
    #endregion

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        else
            StartCoroutine(PlayerAttack());
    }

    IEnumerator PlayerAttack() {
        Debug.Log("Attacking");
        Debug.Log("Player monster = " + playerMonster.name);
        Debug.Log("Enemy monster = " + enemyUnit.name);
        enemyUnit.TakeDamage(playerMonster.attack, playerMonster.type);
        yield return new WaitForSeconds(2f);
        enemyUnit.StatusCheck();
        if (enemyUnit.GetStatus()) {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

        else {
            state = BattleState.WON;
            StartCoroutine(EndBattle());
        }
    }

    IEnumerator EndBattle() {
        if (state == BattleState.WON)
        {
            statusUpdate.text = "You won!";
            playerMonster.GainExp(enemyUnit.expReward);
            yield return new WaitForSeconds(2f);
            if (playerMonster.GetExp() >= 100)
                InitiateLevelUp();
            else
            {
                gameControl.StopBattleUI();
            }
                //sceneMover.LoadLevel("Overword");
        }

        else if (state == BattleState.LOST)
        {
            statusUpdate.text = "You lost...";
            yield return new WaitForSeconds(2f);
            sceneMover.LoadLevel("Title screen");
        }  
    }

    IEnumerator EnemyTurn() {
        Debug.Log("enemy Turn");
        int decision = Random.Range(0, 4);
        if (decision >= 2)
        {
            statusUpdate.text = enemyUnit.name + " is attacking!";
            
            yield return new WaitForSeconds(2f);
            playerMonster.TakeDamage(enemyUnit.attack, enemyUnit.type);
            //statusUpdate.text = "You took " + dmg + " damage";
            playerMonster.StatusCheck();

        }
        yield return new WaitForSeconds(1f);
        if (playerMonster.GetStatus())
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
        else {
            state = BattleState.LOST;
            StartCoroutine(EndBattle());
        }

    }

    void InitiateLevelUp() {
        int preAtk = playerMonster.attack;
        int preDef = playerMonster.defense;
        int preLevel = playerMonster.currLevel;
        int preMaxHP = playerMonster.maxHealth;
        battlePanel.SetActive(false);
        levelupPanel.SetActive(true);
        playerMonster.LevelUp();
        levelNameText.text = playerMonster.name;
        levelMaxHpText.text = "Max HP: " + preMaxHP + " -> " + playerMonster.maxHealth;
        levelAtkText.text = "Atk: " + preAtk + " -> " + playerMonster.attack;
        levelDefText.text = "Def: " + preDef + " -> " + playerMonster.defense;
        levelText.text = "Lvl: " + preLevel + " -> " + playerMonster.currLevel;
    }
}

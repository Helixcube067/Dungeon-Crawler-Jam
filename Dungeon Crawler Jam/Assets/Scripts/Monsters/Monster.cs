using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for thep purposes of getting the type advantages and disadvantages working im gonna use fire grass and water here
public enum Type{Fire, Grass, Water}
[CreateAssetMenu(fileName = "New Monster", menuName = "ScriptableObjects/New Monster", order = 1)]
public class Monster : ScriptableObject
{
    public int maxHealth, attack, defense, currHealth;
    public new string name;
    public Sprite monsterPic;
    public Type type;
    public Type weakness;
    public float baseCatchRate;
    float addedCatchRate = 0f;
    bool isAlive = true;
    public void TakeDamage(int unmitigatedDmg, Type damageType)
    {
        //weakness calculations with a 1.5 ratio boost
        if (damageType == weakness)
            unmitigatedDmg = Mathf.CeilToInt(unmitigatedDmg * 1.5f);
        int calculatedDamage = unmitigatedDmg - defense;
        currHealth -= calculatedDamage;
        //accounting for negative values
        if (currHealth < 0)
            currHealth = 0;
        StatusCheck();
    }

    public void Heal(int healValue) {
        currHealth += healValue;
        //accounting for overflow heal values
        if (currHealth > maxHealth)
            currHealth = maxHealth;
    }

    public void StatusCheck()
    {
        if (currHealth <= 0)
            isAlive = true;
        else
            isAlive = false;
    }

    public bool GetStatus() {
        return isAlive;    
    }

    public float CalculateCatchRate() {
        if (currHealth >= (currHealth * 75))
            addedCatchRate = 10f;
        else if (currHealth >= (currHealth * 50))
            addedCatchRate = 15f;
        else if (currHealth >= (currHealth * 25))
            addedCatchRate = 20f;
        else
            addedCatchRate = 0;
        return baseCatchRate + addedCatchRate;
    }
}

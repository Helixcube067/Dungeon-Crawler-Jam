using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParty : MonoBehaviour
{
    public static PlayerParty instance;
    public Monster[] party = new Monster[6] {null, null, null, null, null, null};
    void Awake()
    {
        if (instance == null)
            instance = new PlayerParty();    
    }

    //dont actually need this just check if next alive is null for the loss condition
    /* bool PartyWipe() {
        for (int i = 0; i < party.Length; i++) {
            if (party[i].GetStatus())
                return true;
        }
        return false;
    }*/
    public void CatchMonster(Monster capturedMonster) {
        for (int i = 0; i < party.Length; i++)
        {
            if (party[i] == null) {
                SwitchMonster(capturedMonster, i);
                return;
            }
        }
    }

    public void SwitchMonster(Monster capturedMonster, int position){
        party[position] = capturedMonster;
    }

    public Monster GetNextAlive() {
        for (int i = 0; i < party.Length; i++)
        {
            if (party[i].GetStatus())
                return party[i];
        }
        return null;
    }
}

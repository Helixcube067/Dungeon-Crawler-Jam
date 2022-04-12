using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerParty : MonoBehaviour
{
    public static PlayerParty instance;
    public Monster[] party = new Monster[6] {null, null, null, null, null, null};
    void Awake()
    {
        if (instance == null)
            instance = new PlayerParty();    
    }

    // returns an array of active monsters 1 = not null
    private int[] ActiveMonsters()
    {
        int[] count = new int[6];

        
        for(int i = 0; i < party.Length; i++)
        {
            if(party[i] != null)
            {
                count[i] = 1;
            }
            else
            {
                count[i] = 0;
            }
        }

        return count;
    }

    public Monster GetNext(int index)
    {
        if(party[index] == null)
        {
            Debug.Log("Try again");
            return null;
        }
        else
        {
            return party[index];
        }
    }

    public bool PartyWipe() {
        for (int i = 0; i < party.Length; i++) {
            if (party[i].GetStatus())
                return true;
        }
        return false;
    }
}

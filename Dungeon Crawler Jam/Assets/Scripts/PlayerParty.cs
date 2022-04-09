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

    public bool PartyWipe() {
        for (int i = 0; i < party.Length; i++) {
            if (party[i].GetStatus())
                return true;
        }
        return false;
    }
}

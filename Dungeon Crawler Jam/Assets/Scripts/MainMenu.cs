using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MainMenu : MonoBehaviour
{
    //public GameObject monsterHolder;
    public TextMeshProUGUI leader;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLeader()
    {
        leader.text = "lvl" + PlayerParty.instance.party[0].currLevel + " " + PlayerParty.instance.party[0].name;
    }

    public void SwapPositions()
    {

    }
}

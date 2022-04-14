using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    //public GameObject monsterHolder;
    public TextMeshProUGUI leader;
    public TextMeshProUGUI floorText;
    public TextMeshProUGUI[] reserves;
    public Monster tester, tester2, tester3;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwapPositions(int position)
    {
        if (PlayerParty.instance.party[position] != null) {
            Monster holder = PlayerParty.instance.party[0];
            PlayerParty.instance.party[0] = PlayerParty.instance.party[position];
            PlayerParty.instance.party[position] = holder;
        }
        UpdateParty();
    }

    public void UpdateParty(){
        floorText.text = "Floor: " + SceneManager.GetActiveScene().name;
        leader.text = "Lvl " + PlayerParty.instance.party[0].currLevel + " " + PlayerParty.instance.party[0].name + " (HP: " + PlayerParty.instance.party[0].currHealth + "/" + PlayerParty.instance.party[0].maxHealth + ")";
        for (int i = 0; i < reserves.Length; i++) {
            if (PlayerParty.instance.party[i + 1] != null)
                reserves[i].text = "Lvl " + PlayerParty.instance.party[i + 1].currLevel + " " + PlayerParty.instance.party[i + 1].name + " HP: (" + PlayerParty.instance.party[i + 1].currHealth + "/" + PlayerParty.instance.party[i + 1].maxHealth + ")";
            else
                reserves[i].text = "(Empty slot)";
        }
    }
}

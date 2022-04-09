using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StarterDecision : MonoBehaviour
{
    public TextMeshProUGUI selectionText;
    private Monster selectedStarter = null;

    void Update()
    {
        if (selectedStarter == null)
            selectionText.text = "Select a starter";
        else
            selectionText.text = "You've chosen: " + selectedStarter.name + " the " + selectedStarter.type + " type";
    }

    public void SelectStarter(Monster monster) {
        selectedStarter = monster;
    }
    public void ObtainStarter() {
        PlayerParty.instance.party[0] = selectedStarter;
    }


}

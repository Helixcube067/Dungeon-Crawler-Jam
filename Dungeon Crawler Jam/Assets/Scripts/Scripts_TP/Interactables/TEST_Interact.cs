using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_Interact : Interactable_Base
{
    private bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void OnUse()
    {
        InteractionText = "Press F to ";
        isOpen = !isOpen;

        InteractionText += isOpen ? "open" : "close";

        Debug.Log("Used the item");
    }
}

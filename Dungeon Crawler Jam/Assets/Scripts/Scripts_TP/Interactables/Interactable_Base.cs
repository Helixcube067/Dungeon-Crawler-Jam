using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Base : MonoBehaviour 
{
    public string Name;
    public string InteractionText = "Press F to interact";

    public virtual void OnUse()
    {

    }

    
}

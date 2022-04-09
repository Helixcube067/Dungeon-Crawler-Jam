using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreSceneDialogue : MonoBehaviour
{
    public DialogueTrigger trigger;

    void Start()
    {
        trigger.TriggerPreSceneDialogue(); 
    }
}

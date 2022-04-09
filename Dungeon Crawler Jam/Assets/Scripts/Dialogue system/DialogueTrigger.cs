using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    /* This class is used to trigger dialogue and it finds the dialogue manager and then calls start dialogue
     * 
     * To use: Slap this onto what you want to trigger the dialogue and then self reference to use this script
     */
    public Dialogue dialogue;
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void TriggerPreSceneDialogue() {
        FindObjectOfType<DialogueManager>().StartPreSceneDialogue(dialogue);
    }
}

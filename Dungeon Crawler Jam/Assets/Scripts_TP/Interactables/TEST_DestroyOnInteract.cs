using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_DestroyOnInteract : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject interactionText;

    

    [SerializeField]
    private const float maxRange = 1.0f;
    public float MaxRange { get { return maxRange; } }

    public void OnStartHover()
    {
        Debug.Log("On sTart destroy");
        interactionText.SetActive(true);
        // Set the UI to active
    }

    public void OnInteract()
    {
        // call the event.
    }

    public void OnEndHover()
    {
        Debug.Log("On end destroy");
        // reset text
        // disable the ui
        interactionText.SetActive(false);
    }

}

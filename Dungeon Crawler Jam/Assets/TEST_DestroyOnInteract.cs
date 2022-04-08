using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_DestroyOnInteract : MonoBehaviour, IInteractable
{
    private const float maxRange = 1.5f;
    public float MaxRange { get { return maxRange; } }

    public void OnStartHover()
    {
        Debug.Log($"Ready to destroy {gameObject.name}");
    }

    public void OnInteract()
    {
        Destroy(gameObject);
    }

    public void OnEndHover()
    {            
        Debug.Log("We have destroyed");
    }

}

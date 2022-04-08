using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interactions : MonoBehaviour
{
    [SerializeField] private float range;

    private IInteractable currentTarget;

    private void Update()
    {
        RaycastForInteractable();

        if(Input.GetKeyDown(KeyCode.F))
        {
            if(currentTarget != null)
            {
                currentTarget.OnInteract();
            }
        }
    }

    private void RaycastForInteractable()
    {
        RaycastHit interactableHit;

        Ray ray = new Ray(transform.position, transform.forward);

        Debug.DrawRay(transform.position, transform.forward);


        if(Physics.Raycast(ray, out interactableHit, range))
        {

            // Get the script for the interactable item.
            IInteractable interactable = interactableHit.collider.GetComponent<IInteractable>();

            if(interactable != null)
            {
                Debug.Log("Hit an interactable!");
                // If the object is within range
                if(interactableHit.distance <= interactable.MaxRange)
                {
                    if(interactable == currentTarget)
                    {
                        return;
                    }
                    else if(currentTarget != null)
                    {
                        currentTarget.OnEndHover();
                        currentTarget = interactable;
                        currentTarget.OnStartHover();
                        return;
                    }
                    else
                    {
                        currentTarget = interactable;
                        currentTarget.OnStartHover();
                        return;
                    }
                }
                else
                {
                    if(currentTarget != null)
                    {
                        currentTarget.OnEndHover();
                        currentTarget = null;
                        return;
                    }
                }
            }
            else
            {
                if (currentTarget != null)
                {
                    currentTarget.OnEndHover();
                    currentTarget = null;
                    return;
                }
            }
        }
        else
        {
            if (currentTarget != null)
            {
                currentTarget.OnEndHover();
                currentTarget = null;
                return;
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StairsUp : MonoBehaviour, IInteractable
{
    [Tooltip("Destination Scene")]
    public SceneNames scene;

    [SerializeField]
    private GameObject interactionText;

    [SerializeField]
    private GameControl gameControl;

    [SerializeField]
    private SceneMovement sceneMovement;

    [SerializeField]
    private float maxRange = .5f;

    public float MaxRange { get { return maxRange; } }

    public void OnStartHover()
    {
        interactionText.SetActive(true);
    }

    public void OnInteract()
    {
        // increment level by 1
        gameControl.currentLevel += 1;
        // Scene manager reset level
        sceneMovement.LoadLevel(/*level string*/"Level_Dungeon");
    }

    public void OnEndHover()
    {
        interactionText.SetActive(false);
    }
}

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
    private float maxRange = .5f;

    public float MaxRange { get { return maxRange; } }

    public void OnStartHover()
    {
        interactionText.SetActive(true);
    }

    public void OnInteract()
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void OnEndHover()
    {
        interactionText.SetActive(false);
    }
}

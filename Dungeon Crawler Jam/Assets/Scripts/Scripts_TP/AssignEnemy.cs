using UnityEngine;
using UnityEngine.UI;

public class AssignEnemy : MonoBehaviour
{
    private Monster currentEnemy;
    private GameControl gameControl;
    [SerializeField]
    private Image imageUI; // Target UI slot to display monster image.

    private void OnEnable()
    {
        // assign the image object the sprite provided
        Debug.Log("Enabled");
        Debug.Log("Assigned to current Enemy" + currentEnemy.name);
        //currentEnemy = gameControl.currentEnemy;
        if (currentEnemy)
        {
            imageUI.sprite = currentEnemy.monsterPic;
        }    
    }

    public Monster GetCurrentEnemy()
    {
        return currentEnemy;
    }

    public void SetEnemy(Monster monster)
    {
        currentEnemy = monster;
        Debug.Log("Assigned to current Enemy" + currentEnemy.name);
    }

}

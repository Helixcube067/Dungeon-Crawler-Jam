using UnityEngine;
using UnityEngine.UI;

public class AssignEnemy : MonoBehaviour
{
    private Monster currentEnemy;

    [SerializeField]
    private Image imageUI;

    private void OnEnable()
    {
        // assign the image object the sprite provided
        if(currentEnemy)
        {
            imageUI.sprite = currentEnemy.monsterPic;
        }    
    }

    public void SetEnemy(Monster monster)
    {
        currentEnemy = monster;    
    }

}

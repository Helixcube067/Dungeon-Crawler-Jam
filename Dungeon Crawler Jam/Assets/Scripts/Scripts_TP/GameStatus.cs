using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    public int numLive = 3;
    public int score = 0;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}

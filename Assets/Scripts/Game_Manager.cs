using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{

    
    public Game_Over GameOverScript;
    public int score;

    public void endGame()
    {
        Debug.Log("Game Over");
        GameOverScript.Setup(score);
    }

}

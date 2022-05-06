using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{

    
    public Game_Over GameOverScript;
    public CarController Player_script;
    public int score;


    private void Update()
    {
        score = Player_script.get_points();
    }


    public void endGame()
    {
        Debug.Log("Game Over");
        GameOverScript.Setup(score);
    }

}

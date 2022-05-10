using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{

    
    public Game_Over GameOverScript;
    public Tutorial_Over TutorialOverScript;
    public CarController Player_script;
    public Text pointsCounter;
    public int score;


    private void Update()
    {
        pointsCounter.text = "Points: " + score.ToString();
        score = Player_script.get_points();
    }


    public void endGame()
    {
        Debug.Log("Game Over");
        GameOverScript.Setup(score);
        //score = Player_script.reset_points();
    }

    public void endTutorial()
    {
        TutorialOverScript.Setup(score);
    }
}

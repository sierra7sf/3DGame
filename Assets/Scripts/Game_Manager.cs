using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{

    public bool GameOver = false;
    public Game_Over GameOverScript;
    public Tutorial_Over TutorialOverScript;
    public CarController Player_script;
    public Text pointsCounter;
    public int score;
    public int finalScore;



    private void Update()
    {
        if(GameOver == false)
        {
            pointsCounter.text = "Points: " + score.ToString();
            score = Player_script.get_points();
            finalScore = score;
        }

    }


    public void endGame()
    {
        GameOver = true;
        GameOverScript.Setup(finalScore);
        score = Player_script.reset_points();
        Player_script.movementSpeed = 0;
    }

    public void endTutorial()
    {
       TutorialOverScript.Setup(score);
       Player_script.movementSpeed = 0;
    }
}

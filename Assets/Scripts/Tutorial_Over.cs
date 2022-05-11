using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial_Over : MonoBehaviour
{
    public Text pointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = "Points: " + score.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndlessRunnerButton()
    {
        SceneManager.LoadScene("EndlessRunner");
    }

}
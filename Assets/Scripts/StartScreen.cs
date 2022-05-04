using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{

    public void Tutorial()
    {
        SceneManager.LoadScene("BaseScene");
    }

    public void LevelOne()
    {
        SceneManager.LoadScene("BaseScene");
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("BaseScene");
    }

    public void LevelThree()
    {
        SceneManager.LoadScene("BaseScene");
    }

    public void Quit()
    {
        Application.Quit();
    }



}

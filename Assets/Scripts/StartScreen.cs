using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{

    public void Tutorial()
    {
        SceneManager.LoadScene("Level 1");
    }
    
    public void EndlessRunner()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void Quit()
    {
        Application.Quit();
    }



}

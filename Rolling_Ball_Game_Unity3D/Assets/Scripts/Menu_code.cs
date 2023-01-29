using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_code : MonoBehaviour
{
    private bool i = true;

    public void Level_1()
    {
        SceneManager.LoadScene(1);
    }

    public void Level_2()
    {
        SceneManager.LoadScene(2);
    }

    public void Level_3()
    {
        SceneManager.LoadScene(3);
    }
    
    public void Pause()
    {
        if (i)
        {
            Time.timeScale = 0;
            i = !i;
        }
        else
        {
            Time.timeScale = 1;
            i = !i;
        }
    }

    public void Back()
    {        
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

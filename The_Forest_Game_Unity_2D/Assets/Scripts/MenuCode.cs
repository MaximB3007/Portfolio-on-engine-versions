using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCode : MonoBehaviour
{
    private bool timeIsGoing = true;

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

    public void Level_4()
    {
        SceneManager.LoadScene(4);
    }

    public void Level_5()
    {
        SceneManager.LoadScene(5);
    }

    public void Pause()
    {
        if (timeIsGoing)
        {
            Time.timeScale = 0;
            timeIsGoing = !timeIsGoing;
        }
        else
        {
            Time.timeScale = 1;
            timeIsGoing = !timeIsGoing;
        }
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

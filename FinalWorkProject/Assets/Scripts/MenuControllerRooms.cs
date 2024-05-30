using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControllerRooms : MonoBehaviour
{
    public void GoToGen4()
    {
        SceneManager.LoadScene("Gen4");
    }
    public void GoToGen5()
    {
        SceneManager.LoadScene("Gen5");
    }
    public void GoToGen6()
    {
        SceneManager.LoadScene("Gen6");
    }
    public void GoToGen7()
    {
        SceneManager.LoadScene("Gen7");
    }
    public void GoToGen8()
    {
        SceneManager.LoadScene("Gen8");
    }
    public void GoToGen9()
    {
        SceneManager.LoadScene("Gen9");
    }
    public void GoToMuseum()
    {
        SceneManager.LoadScene("Museum");
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }
    public void GoToTimeline()
    {
        SceneManager.LoadScene("Timeline");
    }
    
}

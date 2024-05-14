using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControllerRooms : MonoBehaviour
{
    public void GoToGen4()
    {
        SceneManager.LoadScene("FinalWorkProject-Gen4");
    }
    public void GoToGen5()
    {
        SceneManager.LoadScene("FinalWorkProject-Gen5");
    }
    public void GoToGen6()
    {
        SceneManager.LoadScene("FinalWorkProject-Gen6");
    }
    public void GoToGen7()
    {
        SceneManager.LoadScene("FinalWorkProject-Gen7");
    }
    public void GoToGen8()
    {
        SceneManager.LoadScene("FinalWorkProject-Gen8");
    }
    public void GoToGen9()
    {
        SceneManager.LoadScene("FinalWorkProject-Gen9");
    }
    public void GoToAllGen()
    {
        SceneManager.LoadScene("FinalWorkProject-All");
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

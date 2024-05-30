using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControllerTimeline : MonoBehaviour
{
    public void GoTo1989()
    {
        SceneManager.LoadScene("Gen3");
    }
    public void GoTo1995()
    {
        SceneManager.LoadScene("Gen4");
    }
    public void GoTo1998()
    {
        SceneManager.LoadScene("Gen5");
    }
    public void GoTo2003()
    {
        SceneManager.LoadScene("Gen6");
    }
    public void GoTo2010()
    {
        SceneManager.LoadScene("Gen7");
    }
    public void GoTo2017()
    {
        SceneManager.LoadScene("Gen8");
    }
    public void GoTo2024()
    {
        SceneManager.LoadScene("Gen9");
    }
    public void GoToMuseum()
    {
        SceneManager.LoadScene("Museum");
    }
}

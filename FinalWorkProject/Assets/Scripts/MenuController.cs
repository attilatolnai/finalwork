using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartBtn(){
        SceneManager.LoadScene("FinalWorkProject-Gen3");
    }
    public void TimelineBtn(){
        SceneManager.LoadScene("Timeline");
    }
    public void MuseumBtn(){
        SceneManager.LoadScene("FinalWorkProject-All");
    }
}

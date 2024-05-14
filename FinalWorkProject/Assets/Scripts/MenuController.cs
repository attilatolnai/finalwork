using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("FinalWorkProject-Gen3");
    }
    public void Museum()
    {
        SceneManager.LoadScene("Timeline");
    }
    
}

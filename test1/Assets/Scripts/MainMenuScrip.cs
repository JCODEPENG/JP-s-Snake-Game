using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuScrip : MonoBehaviour
{

    public void btnstart(string var)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(var);

    }
    //Scene 
}

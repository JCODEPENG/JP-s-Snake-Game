using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/***
 * Controls gameover screen
 */


public class GameOverBtn : MonoBehaviour
{
    
    private static GameOverBtn instance;
    GameObject resumebtn;
    GameObject quitbtn;
    bool flag;
    public void TakeinButton (string var)
    {  
        SceneManager.LoadScene(var);
        hide();
    }
    public void btnstart(string var)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(var);

    }

    public void Show()
    {
        flag = true;
    }
    public void hide()
    {
        flag = false;
    }
    public static void Showstatic()
    {
        instance.Show();
    }
    public void Start()
    { 
        resumebtn = GameObject.FindGameObjectWithTag("ResumeBtn");
        quitbtn = GameObject.FindGameObjectWithTag("QuitBtn");
        flag = false;
        instance = this;
    }
    public void Update()
    {
        if (flag == false)
        {
            resumebtn.SetActive(false);
            quitbtn.SetActive(false);
        }
        else
        {
            resumebtn.SetActive(true);
            quitbtn.SetActive(true);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverBtn : MonoBehaviour
{
    
    private static GameOverBtn instance;
    GameObject btn;
    GameObject quitbtn;
    bool flag;
    public void TakeinButton (string var)
    {
        Debug.Log("Running?");
       

        //Scene scene = var;
        
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
        btn = GameObject.FindGameObjectWithTag("ShowBtn");
        quitbtn = GameObject.FindGameObjectWithTag("QuitBtn");
        flag = false;
        instance = this;
    }
    public void Update()
    {
        Debug.Log(flag);
        if (flag == false)
        {
            btn.SetActive(false);
            quitbtn.SetActive(false);
        }
        else
        {
            btn.SetActive(true);
            quitbtn.SetActive(true);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/***
 * This Pausemenu class allows the user to pause the game and select what the user wants to
 * do next. Such as continue the game or leave the game.
 */



public class Pausemenu : MonoBehaviour
{
    
    private static Pausemenu instance;
    public void btnresume(string var)
    {
        gamehandler.ResumeGame();
    }
    public void btnquit(string var)
    {
        SceneManager.LoadScene(var);
    }
    private void hide()
    {
        gameObject.SetActive(false);
    }
    private void Awake()
    {
        instance = this;
        hide();
    }
    private void show()
    {
        gameObject.SetActive(true);
    }
    public static void HideStatic()
    {
        instance.hide();
    }
    public static void ShowStatic()
    {
        instance.show();
    }
}

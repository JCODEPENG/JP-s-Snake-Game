using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/***
 * The main menu class just holds the main menu screen that is imported
 * from the editor in Unity
 */
public class MainMenuScript : MonoBehaviour
{

    public void btnstart(string var)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(var);

    }
   
}

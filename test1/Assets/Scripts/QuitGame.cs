using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void quitgame()
    {
        Debug.Log("has quit the game");
        Application.Quit();
    }
}

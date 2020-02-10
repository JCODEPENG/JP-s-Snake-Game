using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***
 * Class to quit the game
 */

public class QuitGame : MonoBehaviour
{
    public void quitgame()
    {
        Debug.Log("has quit the game");
        Application.Quit();
    }
}

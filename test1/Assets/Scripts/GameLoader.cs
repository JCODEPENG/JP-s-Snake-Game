using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameLoader
{
    public enum Scene
    {
        //two states
        GameScene,
        Loading,
    }

    private static Action loaderCallBackAction;

    public static void Load(Scene scene)
    {
        loaderCallBackAction = () =>
        {


            SceneManager.LoadScene(Scene.Loading.ToString());
        };

        SceneManager.LoadScene(scene.ToString());
    }
    public static void LoaderCallBack()
    {
        if (loaderCallBackAction != null)
        {
            loaderCallBackAction();
            loaderCallBackAction = null; 
        }
    }
}

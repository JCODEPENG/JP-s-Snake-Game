using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets instance;
    private void Awake()
    {
        instance = this;
    }

    //place images for this on what you want your snake to look like 
    public Sprite snakeHeadSprite;
    public Sprite foodSprite;
    public Sprite snakebody;
}

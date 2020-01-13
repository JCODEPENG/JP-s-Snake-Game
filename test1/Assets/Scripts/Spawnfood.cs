using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelGrid
{
    private Vector2Int foodgridpos;
    private GameObject foodGameobject;
    private int width;
    private int height;
    private Snek snek;

    public LevelGrid(int width, int height)
    {
        this.width = width;
        this.height = height;


    }

    public void Setup(Snek snek)
    {
        this.snek = snek;
        Spawnvoid();
    }

    private void Spawnvoid()
    {
        do
        {
            foodgridpos = new Vector2Int(Random.Range(0, width), Random.Range(0, height));
        } while (snek.GetGridPosition() == foodgridpos);

        foodGameobject = new GameObject("Food", typeof(SpriteRenderer));
        foodGameobject.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.foodSprite;
        foodGameobject.transform.position = new Vector3(foodgridpos.x, foodgridpos.y);

    }

    public bool SnakeMoves(Vector2Int SnakeGridPos)
    {
        if (SnakeGridPos == foodgridpos)
        {
            Object.Destroy(foodGameobject);
            Spawnvoid();
            return true; 

        }
        else
        {
            return false; 
        }
    }
    public Vector2Int validGridPos(Vector2Int Gridposition)
    {
        if (Gridposition.x < 0)
        {
            Gridposition.x = width - 1;
        }
        if(Gridposition.y < 0)
        {
            Gridposition.y = height - 1;
        }
        if (Gridposition.x >= 20)
        {
            Gridposition.x = 0;
        }
        if (Gridposition.y >= 20)
        {
            Gridposition.y = 0;
        }
        return Gridposition;
    }
}

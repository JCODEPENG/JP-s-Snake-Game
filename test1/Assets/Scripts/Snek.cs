using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snek : MonoBehaviour
{

    private enum DIRECTION
    {
        left,
        right,
        up,
        down

    }

    private enum DOA
    {
        Alive,
        Dead
    }

    private DOA doa;
    private DIRECTION movedirection;
    private Vector2Int gridPosition;
    private float gridmoveTimer;
    private float gridmoveTimerMax;
    private LevelGrid levelGrid;
    private int snakebodysize;
    private List<singleGridPos> snakepositionlist;
    private List<SnakeBodyPart> tranformsnakebody;



    public void SetUP(LevelGrid levelGrid)
    {
        this.levelGrid = levelGrid;
    }

    private void Awake()
    {
        gridPosition = new Vector2Int(10, 10);
        gridmoveTimerMax = .3f;
        gridmoveTimer = gridmoveTimerMax;
        movedirection = DIRECTION.right;

        snakepositionlist = new List<singleGridPos>();
        snakebodysize = 0;
        tranformsnakebody = new List<SnakeBodyPart>();
        doa = DOA.Alive;


    }

    private void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (movedirection != DIRECTION.down)
            {
                movedirection = DIRECTION.up;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (movedirection != DIRECTION.up)
            {
                movedirection = DIRECTION.down;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (movedirection != DIRECTION.right)
            {
                movedirection = DIRECTION.left;
            }

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (movedirection != DIRECTION.left)
            {
                movedirection = DIRECTION.right;
            }
        }
    }

    private float GetAngleFunction(Vector2Int dir)
    {
        float i = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (i < 0)
        {
            i += 360;

        }
        return i;


    }



    private void Update()
    {
        if (doa == DOA.Alive){
            Inputs();
            gridmoveTimer += Time.deltaTime;
            if (gridmoveTimer >= gridmoveTimerMax)
            {
                gridmoveTimer = gridmoveTimer - gridmoveTimerMax;

                singleGridPos previousSnakeMove = null;
                if (snakepositionlist.Count > 0)
                {
                    previousSnakeMove = snakepositionlist[0];
                }
                singleGridPos snakeMovePosition = new singleGridPos(previousSnakeMove, gridPosition, movedirection);

                snakepositionlist.Insert(0, snakeMovePosition);

                Vector2Int gridMoveDirectionVector;
                switch (movedirection)
                {
                    default:
                    case DIRECTION.right: gridMoveDirectionVector = new Vector2Int(+1, 0); break;
                    case DIRECTION.left: gridMoveDirectionVector = new Vector2Int(-1, 0); break;
                    case DIRECTION.up: gridMoveDirectionVector = new Vector2Int(0, +1); break;
                    case DIRECTION.down: gridMoveDirectionVector = new Vector2Int(0, -1); break;

                }

                gridPosition = gridPosition + gridMoveDirectionVector;

                gridPosition = levelGrid.validGridPos(gridPosition);

                bool snakehaseaten = levelGrid.SnakeMoves(gridPosition);
                if (snakehaseaten)
                {
                    snakebodysize++;
                    CreateSnakeBodyPart();
                }

                if (snakepositionlist.Count >= snakebodysize + 1)
                {
                    snakepositionlist.RemoveAt(snakepositionlist.Count - 1);
                }

                UpdateSnakeBodyParts();

                foreach (SnakeBodyPart snakebodypart in tranformsnakebody)
                {
                    Vector2Int snakebodypartgridpos = snakebodypart.GetGridPosition();
                    if (gridPosition == snakebodypartgridpos)
                    {

                        doa = DOA.Dead;
                      //situation.Show();
                        gamehandler.Snakedeath();
                        Debug.Log("Dead");
                     }
                }

                transform.position = new Vector3(gridPosition.x, gridPosition.y);
                transform.eulerAngles = new Vector3(0, 0, GetAngleFunction(gridMoveDirectionVector) - 90);

                


            }
        }

    }

 


    public Vector2Int GetGridPosition()
    {
        return gridPosition;
    }

    // Return the full list of positions occupied by the snake: Head + Body
    public List<Vector2Int> GetFullSnakeGridPositionList()
    {
        List<Vector2Int> gridPositionList = new List<Vector2Int>() { gridPosition };
        foreach (singleGridPos singleGridpos in snakepositionlist)
        gridPositionList.Add(singleGridpos.GetGridPosition());
        return gridPositionList;
    }

    private void CreateSnakeBodyPart()
    {
       tranformsnakebody.Add(new SnakeBodyPart(tranformsnakebody.Count));
    }

    private void UpdateSnakeBodyParts()
    {
        for (int i = 0; i < tranformsnakebody.Count; i++)
        {
            tranformsnakebody[i].SetGridPosition(snakepositionlist[i]);
        }
    }

    private class SnakeBodyPart
    {

        private singleGridPos gridPosition;
        private Transform transform;

        public SnakeBodyPart(int bodyIndex)
        {
            GameObject snakeBodyGameObject = new GameObject("SnakeBody", typeof(SpriteRenderer));
            snakeBodyGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.snakebody;
            snakeBodyGameObject.GetComponent<SpriteRenderer>().sortingOrder = -1 - bodyIndex;
            transform = snakeBodyGameObject.transform;
        }

        public void SetGridPosition(singleGridPos gridPosition)
        {
            this.gridPosition = gridPosition;
            transform.position = new Vector3(gridPosition.GetGridPosition().x, gridPosition.GetGridPosition().y);
            float angle;
            switch (gridPosition.GetDirection())
            {
                default:
                case DIRECTION.up:
                    angle = 0;
                    break;
                case DIRECTION.down:
                    angle = 180;
                    break;
                case DIRECTION.left:
                    angle = -90;
                    break;
                case DIRECTION.right:
                    angle = 90;
                    break;
            }

            transform.eulerAngles = new Vector3(0, 0, angle);
        }

        public Vector2Int GetGridPosition()
        {
            return gridPosition.GetGridPosition();
        }
    }

    private class singleGridPos{
        private singleGridPos previousSnakeMove;
        private Vector2Int GridPos;
        private DIRECTION direction;

        public singleGridPos(singleGridPos previousSnakeMove, Vector2Int GridPos, DIRECTION direction)
        {
            this.previousSnakeMove = previousSnakeMove;
            this.GridPos = GridPos;
            this.direction = direction;
        }
        public Vector2Int GetGridPosition()
        {
            return GridPos;
        }
        public DIRECTION GetDirection()
        {
            return direction;
        }
        public DIRECTION GetPrevDirection()
        {
            if (previousSnakeMove == null)
            {
                return DIRECTION.right;
            }
            else
            {
                return previousSnakeMove.direction;
            } 
        }
    }
         
}

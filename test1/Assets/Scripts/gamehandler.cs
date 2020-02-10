using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamehandler : MonoBehaviour


{
    /****
     * The main game handler class that controls and puts the game together
     */
   
    [SerializeField] private Snek snek;
    private LevelGrid levelgrid;
    // Start is called before the first frame update
    void Start()
    {
        levelgrid = new LevelGrid(20, 20);
        snek.SetUP(levelgrid);
        levelgrid.Setup(snek);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamehandler.Pausegame();
        }
    }

    public static void Snakedeath()
    {
        GameOverBtn.Showstatic();
    }
    public static void ResumeGame()
    {
        Pausemenu.HideStatic();
        Time.timeScale = 1f;
    }
    public static void Pausegame()
    {
        Pausemenu.ShowStatic();
        Time.timeScale = 0f;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gamestate
{
    mainMenu,
    ingame,
    minigame,
    credits,
    esc
}

public class DontDestroy : MonoBehaviour
{
    public static List<Vector3> PlayerTileList = new List<Vector3>();
    public static List<int> playerTileArrayPosX = new List<int>();
    public static List<int> playerTileArrayPosY = new List<int>();

    public static bool newGame = true;
    GameObject logic;
    static DontDestroy instance;
    public static Gamestate CurrentGamestate;


    void Awake()
    {
        logic = this.gameObject;
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        CurrentGamestate = Gamestate.mainMenu;
    }


    public void AudioManager()
    {
        if (CurrentGamestate == Gamestate.mainMenu)
        {
            //play main menu music
        }
        if (CurrentGamestate == Gamestate.ingame)
        {
            //play background music
        }
        if (CurrentGamestate == Gamestate.esc)
        {
            //stop playing
        }
        if (CurrentGamestate == Gamestate.credits)
        {
            //play credit music
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gamestate
{
    mainMenu,
    ingame,
    minigame,
    credits
}

public class DontDestroy : MonoBehaviour
{

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


}

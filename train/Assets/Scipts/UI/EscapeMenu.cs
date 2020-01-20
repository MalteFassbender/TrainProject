using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EscapeMenu : MonoBehaviour
{
    public GameObject escapeMenu;
    public GameObject hotbarPanel;
    public static bool escapeMenuIsActive = false;
    void Update()
    {
        EscapeMenuActivation();
    }
    void EscapeMenuActivation()
    {
        if (!escapeMenuIsActive)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !SwitchPlayer.playerMenuIsActive)
            {
                hotbarPanel.SetActive(false);
                escapeMenu.SetActive(true);
                escapeMenuIsActive = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                DontDestroy.CurrentGamestate = Gamestate.esc;
                hotbarPanel.SetActive(true);
                escapeMenu.SetActive(false);
                escapeMenuIsActive = false;
            }
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                DontDestroy.CurrentGamestate = Gamestate.ingame;
            }
        }
    }
}
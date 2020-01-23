using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Start");
        DontDestroy.CurrentGamestate = Gamestate.ingame;
    }
    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
        DontDestroy.CurrentGamestate = Gamestate.credits;
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("Main Menu");
        DontDestroy.CurrentGamestate = Gamestate.mainMenu;
    }
    public void SaveButton()
    {
        Debug.Log("Saved");
    }
}
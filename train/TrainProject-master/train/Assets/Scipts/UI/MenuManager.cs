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
    }
    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
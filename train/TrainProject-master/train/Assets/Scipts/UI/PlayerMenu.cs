using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMenu : MonoBehaviour
{
    public void Player1Button()
    {
        PlayerLogic.currentSelectedChar = 0;
        Debug.Log("Player 1");
    }
    public void Player2Button()
    {
        PlayerLogic.currentSelectedChar = 1;
        Debug.Log("Player 2");
    }
    public void Player3Button()
    {
        PlayerLogic.currentSelectedChar = 2;
        Debug.Log("Player 3");
    }
    public void Player4Button()
    {
        PlayerLogic.currentSelectedChar = 3;
        Debug.Log("Player 4");
    }
}
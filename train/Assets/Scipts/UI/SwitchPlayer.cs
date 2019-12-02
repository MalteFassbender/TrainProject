using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SwitchPlayer : MonoBehaviour
{
    public GameObject playerMenu;
    public GameObject hotbarPanel;
    bool playerMenuIsActive = false;
    void Update()
    {
        PlayerMenuActivation();
    }
    void PlayerMenuActivation()
    {
        if (!playerMenuIsActive)
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                hotbarPanel.SetActive(false);
                playerMenu.SetActive(true);
                playerMenuIsActive = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                hotbarPanel.SetActive(true);
                playerMenu.SetActive(false);
                playerMenuIsActive = false;
            }
        }
    }
}
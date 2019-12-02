using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EscapeMenu : MonoBehaviour
{
    public GameObject escapeMenu;
    public GameObject hotbarPanel;
    bool escapeMenuIsActive = false;
	void Update()
    {
        EscapeMenuActivation();
	}
    void EscapeMenuActivation()
    {
        if (!escapeMenuIsActive)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
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
                hotbarPanel.SetActive(true);
                escapeMenu.SetActive(false);
                escapeMenuIsActive = false;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class InteractableObjects : MonoBehaviour
{
    GameObject text;
    public Text dialog;
    string dialogFileName = "Dialoge.txt";
    string path;
    int lineNumber;
    GameObject player;
    void Start()
    {
        path = Path.Combine(Application.dataPath, dialogFileName);
        player = GameObject.Find("Char");
        text = GameObject.Find("Dialog");
    }
    bool IsNearPlayer()
    {
        foreach (var item in player.GetComponent<Player>().nearTileList)
        {
            if (this == item)
            {
                return true;
            }
        }
        return false;
    }
    void OnMouseOver()
    {
        if (IsNearPlayer())
        {
            lineNumber = 3;
            string[] lines = System.IO.File.ReadAllLines(path);
            dialog.text = lines[lineNumber];
        }
    }
    void OnMouseExit()
    {
        text.SetActive(false);
    }
}
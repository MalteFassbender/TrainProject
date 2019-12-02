using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class DialogManager : MonoBehaviour
{
    bool isTalking = false;
    public Text dialog;
    string dialogFileName = "Dialoge.txt";
    string path;
    int lineNumber;
    private void Start()
    {
        path = Path.Combine(Application.dataPath, dialogFileName);
    }
    void Update()
    {
        Dialoge();
    }
    void Dialoge()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            isTalking = true;
        }
        if (isTalking)
        {
            lineNumber = 0;
            string[] lines = System.IO.File.ReadAllLines(path);
            dialog.text = lines[lineNumber];
        }
    }
}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class DialogManager : MonoBehaviour
{
    static bool isTalking = false;
    public Text textPrefab;
    public Text namesPrefab;
    static Text dialog;
    static Text name;
    string dialogFileName = "Dialoge.txt";
    static string path;
    static int lineNumber;
    public GameObject panel;
    Vector3 dialogPos;
    Vector3 namePos;
    private void Start()
    {
        CreateText();
        path = Path.Combine(Application.dataPath, dialogFileName);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Dialoge(0, "Durchsage vom Zugführer");
        }
    }
    void CreateText()
    {
        dialogPos = new Vector3(-600, 300, 0);
        dialog = Instantiate(textPrefab);
        dialog.transform.SetParent(panel.transform);
        dialog.transform.localPosition = dialogPos;
        namePos = new Vector3(-600, 400, 0);
        name = Instantiate(namesPrefab);
        name.transform.SetParent(panel.transform);
        name.transform.localPosition = namePos;
    }
    public static void Dialoge(int lineNumber, string characterName)
    {
        name.text = characterName;
        string[] lines = File.ReadAllLines(path);
        dialog.text = lines[lineNumber];
    }
}
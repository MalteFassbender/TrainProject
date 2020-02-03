using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    [SerializeField]
    private Transform[] tiles;
    [SerializeField]
    private GameObject winText;

    public static bool youWin;


    public float endTimer = 5f;
    //public Transform tilePrefab;

    void Start()
    {
      //  Instantiate(tilePrefab, transform.position, Quaternion.identity); 
        winText.SetActive(false);
        youWin = false;

    }

    void Update() 
    {
        if (tiles[0].rotation.z == 0 &&
            (tiles[1].rotation.z == 0 || tiles[1].eulerAngles.z == 180) &&
            tiles[2].rotation.z == 0 &&
            tiles[3].rotation.z == 0 &&
            (tiles[4].rotation.z == 0 || tiles[4].eulerAngles.z == 180) &&
            tiles[5].rotation.z == 0 &&
            tiles[6].rotation.z == 0 &&
            (tiles[7].rotation.z == 0 || tiles[7].eulerAngles.z == 180) &&
            tiles[8].rotation.z == 0
            )
        {
            youWin = true;
            winText.SetActive(true);
            Invoke("GoBack", endTimer);
        }

    }
    void GoBack()
    {
         SceneManager.LoadScene("Start");
         PlayerLogic.charList.Clear();
         Global.interactionTypeList.Clear();
    }
}

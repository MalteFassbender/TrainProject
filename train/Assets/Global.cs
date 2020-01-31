using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Global : MonoBehaviour // Malte ist ein Hurensohn
{
    public static bool rightClik = false;

    public GameObject gateway;
    public string loadScene;
    public static bool interacted = false;

    private void Update()
    {
        rightClik = Input.GetMouseButtonDown(1);
    }

    public bool IsInSameWaggon(GameObject tile1, GameObject tile2)
    {
        if (tile1.GetComponent<Tile>().waggonNumber == tile2.GetComponent<Tile>().waggonNumber)
        {
            return true;
        }
        return false;
    }
}

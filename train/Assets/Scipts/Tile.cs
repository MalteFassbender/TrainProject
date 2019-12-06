using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public bool isOccupied;
    public bool isInteractable;

    public int ID;
    public int waggonNumber;
    public int tileArrayPosX;
    public int tileArrayPosY;

    public Material tileHover;
    public Material tileTexture;
    GameObject player;

    public GameObject occupiedObject;


    private void Start()
    {
        player = GameObject.Find("Char");
    }

    void OnMouseOver()
    {
        if (!isOccupied && waggonNumber == player.GetComponent<Player>().playerCurrentWaggon)
        {
            this.GetComponent<Renderer>().material = tileHover;
        }
    }

    void OnMouseExit()
    {
        if (!isOccupied)
        {
            this.GetComponent<Renderer>().material = tileTexture;
        }
    }
}

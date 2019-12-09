using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    public bool isOccupied = false;
    public bool isInteractable = false;

    public int ID;
    public int waggonNumber;
    public int tileArrayPosX;
    public int tileArrayPosY;

    public Material tileHover;
    public Material tileTexture;
    public GameObject occupiedObject;

    void OnMouseOver()
    {
        if (!isOccupied && waggonNumber == PlayerLogic.currentPlayer.GetComponent<Player>().playerCurrentWaggon && !SwitchPlayer.playerMenuIsActive && !EscapeMenu.escapeMenuIsActive)
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

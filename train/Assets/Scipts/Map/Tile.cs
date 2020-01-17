using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    public bool isOccupied = false;
    public bool isInteractable = false;
    public int fromCost;
    public int toCost;
    public int sumCost;
    public GameObject predecessor;


    public int ID;
    public int waggonNumber;
    public int tileArrayPosX;
    public int tileArrayPosY;

    public Material tileHover;
    public Material tileTexture;
    public GameObject occupiedObject;

    public Material currentMaterial;

    void OnMouseEnter()
    {
        currentMaterial = this.GetComponent<Renderer>().material;
        if (!isOccupied && waggonNumber == PlayerLogic.currentPlayer.GetComponent<Player>().playerCurrentWaggon && !SwitchPlayer.playerMenuIsActive && !EscapeMenu.escapeMenuIsActive && !PlayerLogic.isMoving)
        {
            this.GetComponent<Renderer>().material = tileHover;
        }
    }

    void OnMouseExit()
    {
        if (!isOccupied && !PlayerLogic.isMoving)
        {
            this.GetComponent<Renderer>().material = tileTexture;
        }
    }
}

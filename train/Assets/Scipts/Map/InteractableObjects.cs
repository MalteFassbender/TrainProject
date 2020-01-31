using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class InteractableObjects : MonoBehaviour
{
    GameObject text;
    public Text dialog;
    string pressE = "Press E";

    bool isObject = false;
    bool isDoor = false;
    bool notFound = false;



    void Start()
    {
        text = GameObject.Find("Dialog");
        GetObjectkind();
    }

    void GetObjectkind()
    {
        if (this.gameObject.name.Contains("door"))
        {
            isDoor = true;
        }
        if (this.gameObject.name.Contains("Object"))
        {
            isObject = true;
        }
        else
        {
            notFound = true;
        }
    }


    bool IsNearPlayer()
    {
        foreach (var item in PlayerLogic.currentPlayer.GetComponent<Player>().nearTileList)
        {
            if (item != null)
            {

                if (item.GetComponent<Tile>().isOccupied)
                {
                    if (this.gameObject == item.GetComponent<Tile>().occupiedObject)
                    {
                        return true;
                    }

                }
            }
        }
        return false;
    }

    void OnMouseOver()
    {
        if (isObject)
        {

            if (!PlayerLogic.isMoving)
            {

                this.gameObject.GetComponent<Renderer>().material.color = Color.green;
            }
            if (IsNearPlayer())
            {
                text.SetActive(true);
                dialog.text = pressE;
                if (Input.GetKey(KeyCode.E))
                {
                    Global.interacted = true;
                    DontDestroy.newGame = false;
                    foreach (var item in PlayerLogic.charList)
                    {
                        DontDestroy.PlayerTileList.Add(item.GetComponent<Player>().playerCurrentTile.transform.position);
                        DontDestroy.playerTileArrayPosX.Add(item.GetComponent<Player>().playerCurrentTile.GetComponent<Tile>().tileArrayPosX);
                        DontDestroy.playerTileArrayPosY.Add(item.GetComponent<Player>().playerCurrentTile.GetComponent<Tile>().tileArrayPosY);
                    }
                    Starting();
                }
            }
        }

    }
    void Starting()
    {
        SceneManager.LoadScene("Minigame");
    }

    void OnMouseExit()
    {
        if (isObject)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.white;
            text.SetActive(false);
        }
    }

    void GetCurrentTile()
    {
        if (isObject)
        {
            Ray ray = new Ray(this.transform.position, Vector3.down);
            RaycastHit hit;
            int raylenght = 1;
            if (Physics.Raycast(ray, out hit, raylenght))
            {
                if (hit.transform.gameObject.name.Contains("Tile"))
                {
                    hit.transform.gameObject.GetComponent<Tile>().occupiedObject = this.gameObject;
                    hit.transform.gameObject.GetComponent<Tile>().isOccupied = true;
                }
            }
            Debug.DrawRay(ray.origin, ray.direction, Color.green);
        }
    }
}
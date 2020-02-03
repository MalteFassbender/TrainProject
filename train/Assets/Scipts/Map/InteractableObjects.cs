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
    bool isItem = false;


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
        if (this.gameObject.name.Contains("item"))
        {
            isItem = true;
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
                    foreach (var item in PlayerLogic.charList)
                    {
                        DontDestroy.newGame = false;
                        DontDestroy.playerCurrentTiles.Add(item.GetComponent<Player>().playerCurrentTile.transform.position);
                        Vector2Int TileArrayPos = new Vector2Int(item.GetComponent<Player>().playerCurrentTile.GetComponent<Tile>().tileArrayPosX, item.GetComponent<Player>().playerCurrentTile.GetComponent<Tile>().tileArrayPosY);
                        DontDestroy.playerTileArrayPos.Add(TileArrayPos);
                        PlayerLogic.PrefabCharList.Clear();
                    }
                    Starting();
                }
            }
        }

        if (isItem)
        {

            if (!PlayerLogic.isMoving)
            {
                this.gameObject.GetComponent<Renderer>().material.color = Color.green;
                //glow or somethin
            }
            if (IsNearPlayer())
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Inventory.AddItemToInv(this.gameObject.GetComponent<Item>());
                    Destroy(this.gameObject);
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
        if (isItem)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.white;
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
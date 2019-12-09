using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class InteractableObjects : MonoBehaviour
{
    GameObject text;
    public Text dialog;
    string pressE = "Press E";
    public bool interacted = false;

    void Start()
    {
        text = GameObject.Find("Dialog");
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
        this.gameObject.GetComponent<Renderer>().material.color = Color.green;
        if (IsNearPlayer())
        {
            text.SetActive(true);
            Vector3 textPossiton = this.gameObject.transform.position;
            textPossiton.y = textPossiton.y + 1;
            dialog.transform.position = textPossiton;
            dialog.text = pressE;
            if (Input.GetKey(KeyCode.E)) 
            {
                interacted = true;
            }
        }
        
    }

    void OnMouseExit()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.white;
        text.SetActive(false);
    }

    void GetCurrentTile()
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

    //void GetInteractionType()
    //{
    //    bool isType = false;
    //    int i = 0;
    //    foreach (var item in Global.interactionTypeList)
    //    {
    //        //if (this.name = item[i,i])
    //        //{
    //        //    isType = true;
    //        //}
    //        i++;
    //    }
    //    if (!isType)
    //    {
    //        Debug.Log("not an interaction type");
    //    }
    //}
}
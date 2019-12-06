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

    GameObject player;
    bool interacted = false;

    void Start()
    {
        player = GameObject.Find("Char");
        text = GameObject.Find("Dialog");
    }

    bool IsNearPlayer()
    {
        foreach (var item in player.GetComponent<Player>().nearTileList)
        {

            if (this == item.GetComponent<Tile>().occupiedObject)
            if (this == item)
            {
                return true;
            }
        }
        return false;
    }

    void OnMouseOver()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.green;
        if (IsNearPlayer())
        {
            dialog.text = pressE;
            if (Input.GetKey(KeyCode.E))
            {
                interacted = true;
                GetInteractionType();
            }
        }

    }

    void OnMouseExit()
    {
        text.SetActive(false);
    }

    void getCurrentTile()
    {
        Ray ray = new Ray(this.transform.position, Vector3.down); ;
        RaycastHit hit;
        int raylenght = 1;
        if (Physics.Raycast(ray, out hit, raylenght))
        {
            if (hit.transform.gameObject.name.Contains("Tile"))
            {
                hit.transform.gameObject.GetComponent<Tile>().occupiedObject = this.transform.gameObject;
            }
        }
        Debug.DrawRay(ray.origin, ray.direction, Color.green);
    }

    void GetInteractionType()
    {
        bool isType = false;
        int i = 0;
        foreach (var item in Global.interactionTypeList)
        {
            //if (this.name = item[i,i])
            //{
            //    isType = true;
            //}
            i++;
        }
        if (!isType)
        {
            Debug.Log("not an interaction type");
        }
    }
}
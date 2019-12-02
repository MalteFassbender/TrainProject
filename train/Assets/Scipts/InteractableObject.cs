using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    GameObject player;

	void Start ()
    {
        player = GameObject.Find("Char");
    }

    bool IsNearPlayer()
    {
        foreach (var item in player.GetComponent<Player>().nearTileList)
        {
            if (this == item)
            {
                return true;
            }
        }
        return false;
    }

    void OnMouseOver()
    {
        if (IsNearPlayer())
        {
            //do Ui stuff
        }
    }

    void OnMouseExit()
    {
        //remove Ui stuff
    }
}

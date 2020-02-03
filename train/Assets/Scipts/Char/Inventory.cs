using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static List<Item> itemsInInventory = new List<Item>();
    public static List<GameObject> items = new List<GameObject>();
    public static List<Material> itemIcons = new List<Material>();
    public Material tileTexture;
    public static Material tiletexture;

    public static void AddItemToInv(Item _item)
    {
        bool doNotAdd = false;
        if (itemsInInventory.Count >= 10)
        {
            Debug.Log("inventory is full");
            doNotAdd = true;
        }

        foreach (var item in itemsInInventory)
        {
            if (_item == item)
            {
                Debug.Log("item already in inv");
                doNotAdd = true;
            }
        }
        if (!doNotAdd)
        {
            itemsInInventory.Add(_item);
            Debug.Log("added item");
            _item.tile.GetComponent<Renderer>().material = tiletexture;
            _item.tile.GetComponent<Tile>().isOccupied = false;
            _item.tile.GetComponent<Tile>().occupiedObject = null;
            int i = 0;
            foreach (var item in itemsInInventory)
            {
                if (item == _item)
                {
                    //set ui to item img 
                    //using item.itemIcon
                }
                i++;
            }
        }
    }

    public static void RemoveItemFromInv(int slot, bool destroy)
    {
        if (destroy)
        {
            itemsInInventory[slot] = null;
        }
        else
        {
            DropItem(itemsInInventory[slot]);
        }
    }

    public static void DropItem(Item _item)
    {
        GameObject item = _item.itemGO;
        Vector3 itemDropPos = PlayerLogic.currentPlayer.transform.position;
    }
}

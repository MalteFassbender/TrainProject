using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour  {
    public GameObject tile;
    public GameObject itemGO;
    public Material itemIcon;
    public string itemName;
    public int itemID;
    public bool isNote = false;

    private void Start()
    {
        itemGO = this.gameObject;
        itemName = this.gameObject.name;
        int i = 0;
        foreach (var item in Inventory.items)
        {
            if (item == this.gameObject)
            {
                itemIcon = Inventory.itemIcons[i];
            }
            i++;
        }
    }

    void ReadNote(int line)
    {
        //dissplay text
    }
}

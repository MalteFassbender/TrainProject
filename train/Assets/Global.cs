using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{

    public static Dictionary<string, bool> interactionTypeList = new Dictionary<string, bool>();
    public static bool rightClik = false;

    private void Start()
    {
        interactionTypeList.Add("game", false);
        interactionTypeList.Add("beispiel", false);
    }
    private void Update()
    {
        rightClik = Input.GetMouseButtonDown(1);
    }

    public bool IsInSameWaggon(GameObject tile1, GameObject tile2)
    {
        if (tile1.GetComponent<Tile>().waggonNumber == tile2.GetComponent<Tile>().waggonNumber)
        {
            return true;
        }
        return false;
    }
}

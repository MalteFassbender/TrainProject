using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic : MonoBehaviour
{
   

    void Start()
    {
    }

    void Update()
    {
    }
    
    public static List<GameObject> getNearTiles(GameObject tile)
    {
        List<GameObject> returnList = new List<GameObject>();
        int currentTileWaggon = tile.GetComponent<Tile>().waggonNumber;
        int currentTileArrayPosX = tile.GetComponent<Tile>().tileArrayPosX;
        int currentTileArrayPosY = tile.GetComponent<Tile>().tileArrayPosY;
        if (currentTileArrayPosY + 1 <= Map.tileArray.GetUpperBound(2))
        {
            returnList.Add(Map.tileArray[currentTileWaggon, currentTileArrayPosX, currentTileArrayPosY + 1]);
        }
        if (currentTileArrayPosY - 1 >= 0)
        {
            returnList.Add(Map.tileArray[currentTileWaggon, currentTileArrayPosX, currentTileArrayPosY - 1]);
        }
        if (currentTileArrayPosX + 1 <= Map.tileArray.GetUpperBound(1))
        {
            returnList.Add(Map.tileArray[currentTileWaggon, currentTileArrayPosX + 1, currentTileArrayPosY]);

            if (currentTileArrayPosY + 1 <= Map.tileArray.GetUpperBound(2))
            {
                returnList.Add(Map.tileArray[currentTileWaggon, currentTileArrayPosX + 1, currentTileArrayPosY + 1]);
            }
            if (currentTileArrayPosY - 1 >= 0)
            {
                returnList.Add(Map.tileArray[currentTileWaggon, currentTileArrayPosX + 1, currentTileArrayPosY - 1]);
            }
        }
        if (currentTileArrayPosX - 1 >= 0)
        {
            returnList.Add(Map.tileArray[currentTileWaggon, currentTileArrayPosX - 1, currentTileArrayPosY]);
            if (currentTileArrayPosY + 1 <= Map.tileArray.GetUpperBound(2))
            {
                returnList.Add(Map.tileArray[currentTileWaggon, currentTileArrayPosX - 1, currentTileArrayPosY + 1]);
            }
            if (currentTileArrayPosY - 1 >= 0)
            {
                returnList.Add(Map.tileArray[currentTileWaggon, currentTileArrayPosX - 1, currentTileArrayPosY - 1]);
            }
        }
        return returnList;
    }
}
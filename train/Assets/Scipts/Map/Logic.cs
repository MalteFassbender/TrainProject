using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Logic : MonoBehaviour
{
   

    void Start()
    {
    }

    void Update()
    {
        SaveGameToJson();
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

    void SaveGameToJson()
    {
        bool test = false;
        string path;
        if (test)
        {
            int i = 0;
            Vector3Int[] currentTile = new Vector3Int[PlayerLogic.charList.Count];
            int currentplayer;

            foreach (var item in PlayerLogic.charList)
            {
                int waggonNumber = item.GetComponent<Player>().playerCurrentTile.GetComponent<Tile>().waggonNumber;
                int tileArrayPosX = item.GetComponent<Player>().playerCurrentTile.GetComponent<Tile>().tileArrayPosX;
                int tileArrayPosY = item.GetComponent<Player>().playerCurrentTile.GetComponent<Tile>().tileArrayPosY;
                Vector3Int returnValue = new Vector3Int(waggonNumber, tileArrayPosX, tileArrayPosY);
                currentTile[i] = returnValue;
                i++;
            }
            currentplayer = PlayerLogic.currentSelectedChar;

            SaveGame saveObject = new SaveGame();
            saveObject.SetValues(currentTile, currentplayer);
            path = Application.dataPath + "/save.json";
            if (File.Exists(path))
            {
                File.WriteAllText(path, JsonUtility.ToJson(saveObject));
            }
        }
    }
}

public class SaveGame
{
    Vector3Int[] currentTile;
    int currentplayer;

    public void SetValues(Vector3Int[] _currentTile, int _currentplayer)
    {
        this.currentTile = _currentTile;
        this.currentplayer = _currentplayer;
    }

}

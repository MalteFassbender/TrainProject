using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    //interactable object placeholder
    public GameObject interactGO;


    // train stuff //
    public GameObject Tile;
    public static GameObject[,,] tileArray;
    GameObject lastSelectedTile;

    public Material tileTexture;
    public Material tileSelected;
    public Material tileHover;

    public static int waggonCount = 8;
    public static int waggonSizeX = 8;
    public static int waggonSizeY = 20;
    int tileID = 0;

    //char stuffs
    public GameObject char1;
    public GameObject char2;




    void Start()
    {
        tileArray = new GameObject[waggonCount, waggonSizeX + 1, waggonSizeY + 1];
        CeateMap(waggonCount);
        AddPlayersToList();
        SpawnPlayers();
        interactGO.transform.position = tileArray[0, 2, 5].transform.position;
        tileArray[0, 2, 5].GetComponent<Tile>().isOccupied = true;
        tileArray[0, 2, 5].GetComponent<Tile>().occupiedObject = interactGO;
    }


    #region map
    void CeateMap(int waggons)
    {
        for (int k = 0; k < waggons; k++)
        {
            for (int i = 1; i <= waggonSizeX; i++)
            {
                for (int j = 1; j <= waggonSizeY; j++)
                {
                    int trainSpacing = (waggonSizeY + 1) * k;

                    tileArray[k, i, j] = Instantiate(Tile, new Vector3(i, 0, trainSpacing + j), Quaternion.identity);
                    tileArray[k, i, j].GetComponent<Tile>().ID = tileID;
                    tileArray[k, i, j].GetComponent<Tile>().isOccupied = false;
                    tileArray[k, i, j].GetComponent<Tile>().isInteractable = false;
                    tileID++;
                    tileArray[k, i, j].GetComponent<Tile>().waggonNumber = k;
                    tileArray[k, i, j].GetComponent<Tile>().tileArrayPosX = i;
                    tileArray[k, i, j].GetComponent<Tile>().tileArrayPosY = j;
                    tileArray[k, i, j].GetComponent<Renderer>().material = tileTexture;

                }
            }
        }
    }

    void SpawnPlayers()
    {
        int i = 0;
        foreach (var item in PlayerLogic.PrefabCharList)
        {
            Vector3 playerPos = tileArray[i, 1, 1].transform.position;
            tileArray[i, 1, 1].GetComponent<Renderer>().material = tileSelected;
            playerPos.y = playerPos.y + 1;
            PlayerLogic.PrefabCharList[i].GetComponent<Player>().playerCurrentTile = tileArray[i, 1, 1];
            item.GetComponent<Player>().playerCurrentWaggon = i;
            PlayerLogic.charList.Add(Instantiate(item.transform.gameObject, playerPos, Quaternion.identity));
            PlayerLogic.charList[i].GetComponent<Player>().playerCurrentWaggon = i;
            i++;
        }
    }
    #endregion 

    void AddPlayersToList()
    {
        PlayerLogic.PrefabCharList.Add(char1);
        PlayerLogic.PrefabCharList.Add(char2);
    }

    public static GameObject Vector3ToTile(int waggon, int tileArrayPosX, int tileArrayPosY)
    {
        int adjustedArrayPosY = tileArrayPosY - (waggon * waggonSizeY) - (1 * waggon);
        return tileArray[waggon, tileArrayPosX, adjustedArrayPosY];
    }
}

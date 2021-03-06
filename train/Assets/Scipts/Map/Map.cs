﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    //interactable object placeholder
    public GameObject interactGO;
    List<GameObject> items = new List<GameObject>();


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
        SpawnItems();
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
        if (DontDestroy.newGame)
        {
            int i = 0;
            foreach (var item in PlayerLogic.PrefabCharList)
            {
                Vector3 playerPos = tileArray[i, 6, 3].transform.position;
                tileArray[i, 6, 3].GetComponent<Renderer>().material = tileSelected;
                playerPos.y = playerPos.y + 1;
                PlayerLogic.PrefabCharList[i].GetComponent<Player>().playerCurrentTile = tileArray[i, 6, 3];
                item.GetComponent<Player>().playerCurrentWaggon = i;
                PlayerLogic.charList.Add(Instantiate(item.transform.gameObject, playerPos, Quaternion.identity));
                PlayerLogic.charList[i].GetComponent<Player>().playerCurrentWaggon = i;
                i++;
            }
        }
        else
        {
            PlayerLogic.charList.Clear();

            int i = 0;
            foreach (var item in PlayerLogic.PrefabCharList)
            {
                if (item != null && i <= PlayerLogic.playercount)
                {
                    GameObject currentGo;
                    Vector3 playerPos = DontDestroy.playerCurrentTiles[i];
                    playerPos.y = 1;

                    currentGo = Vector3ToTile(i, DontDestroy.playerTileArrayPos[i].x, DontDestroy.playerTileArrayPos[i].y);
                    item.GetComponent<Player>().playerCurrentWaggon = i;

                    PlayerLogic.charList.Add(Instantiate(item.transform.gameObject, playerPos, Quaternion.identity));
                    PlayerLogic.charList[i].GetComponent<Player>().playerCurrentWaggon = i;
                    currentGo.GetComponent<Tile>().occupiedObject = PlayerLogic.charList[i];
                    currentGo.GetComponent<Tile>().isOccupied = true;
                    currentGo.GetComponent<Renderer>().material = tileSelected;
                    PlayerLogic.charList[i].GetComponent<Player>().playerCurrentTile = currentGo;
                    i++;
                }
            }
            DontDestroy.playerCurrentTiles.Clear();
        }

    }

    void SpawnItems()
    {
        int i = 0;
        foreach (var item in GameObject.FindGameObjectsWithTag("item"))
        {
            item.GetComponent<Item>().itemID = i;
            item.transform.position = tileArray[0, 3, 6 + i].transform.position;
            item.GetComponent<Item>().tile = tileArray[0, 3, 6 + i];
            tileArray[0, 3, 6 + i].GetComponent<Tile>().isOccupied = true;
            tileArray[0, 3, 6 + i].GetComponent<Tile>().occupiedObject = item;
            tileArray[0, 3, 6 + i].GetComponent<Renderer>().material = tileSelected;
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
        //int adjustedArrayPosY = tileArrayPosY - (waggon * waggonSizeY) - (waggon * 1);
        return tileArray[waggon, tileArrayPosX, tileArrayPosY];

    }
}

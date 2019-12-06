using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//                                              //
//                  TODO                        //
//                                              //
/*
    save/load

*/



public class Logic : MonoBehaviour
{
    //-----------Train stuff-----------//
    public GameObject Tile;
    //public GameObject Room;
    //public GameObject wagonCase;
    public static GameObject[,,] tileArray;
    GameObject lastSelectedTile;

    public Material tileTexture;
    public Material tileSelected;
    public Material tileHover;

    public static int waggonCount = 8;
    public static int waggonSizeX = 8;
    public static int waggonSizeY = 20;
    int tileID = 0;
    //---------------------------------//


    //----------player stuff-----------//
    public int activeChar;
     
    public GameObject player;

    GameObject playerSpawnTile;
    Vector3 playerSpawnPos = new Vector3();

    public static GameObject playerCurrentTile;
    Vector3 playerCurrentPos = new Vector3();

    GameObject playerNextTile;
    Vector3 playerNextPos = new Vector3();

    public int playerCurrentWaggon;
    public bool isSameWaggon;
    //---------------------------------//


    //----------global stuff-----------//
    bool rightClik = false;
    //---------------------------------//



    private void Awake()
    {

    }

    void Start()
    {
        tileArray = new GameObject[waggonCount , waggonSizeX  +1, waggonSizeY + 1];     
        CeateMap(waggonCount);  
        playerSpawnTile = tileArray[2, 3, 2];                                         
        SpawnPlayer();
    }

    void Update()
    {
        if (!SwitchPlayer.playerMenuIsActive && !EscapeMenu.escapeMenuIsActive)
        {
            MovePlayer();
        }
        rightClik = Input.GetMouseButtonDown(1);
    }

    void CeateMap(int waggons)
    {

        for (int k = 0; k < waggons; k++)
        {
            for (int i = 1; i <= waggonSizeX; i++)
            {
                for (int j = 1; j <= waggonSizeY; j++)
                {
                    int trainSpacing = (waggonSizeY + 1) * k;

                    tileArray[k ,i ,j] = Instantiate(Tile, new Vector3( i, 0, trainSpacing + j), Quaternion.identity);      //set tile position
                    tileArray[k, i, j].GetComponent<Tile>().ID = tileID;                                                        //set tile ID
                    tileID++;
                    tileArray[k, i, j].GetComponent<Tile>().waggonNumber = k;
                    tileArray[k, i, j].GetComponent<Tile>().tileArrayPosX = i;
                    tileArray[k, i, j].GetComponent<Tile>().tileArrayPosY = j;
                    tileArray[k, i, j].GetComponent<Renderer>().material = tileTexture;                                     //give tile Standart texture

                }
            }
        }
    }

    void SpawnPlayer()
    {
        if (!playerCurrentTile)
        {
            playerSpawnPos = playerSpawnTile.transform.position;
            playerSpawnPos.y = 1;
            player.transform.position = playerSpawnPos;
            playerCurrentTile = playerSpawnTile;
            playerCurrentPos = playerCurrentTile.transform.position;
            playerCurrentTile.GetComponent<Renderer>().material = tileSelected;
            player.GetComponent<Player>().playerCurrentWaggon = playerCurrentTile.GetComponent<Tile>().waggonNumber;
            isSameWaggon = true;

        }
    }

    void MovePlayer()
    {
        if (rightClik)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int raylenght = 2000;
            Debug.DrawRay(ray.origin, ray.direction, Color.green);
            
            if (Physics.Raycast(ray, out hit, raylenght))
            {
                if (hit.transform.gameObject.name.Contains("Tile"))
                {
                    bool fieldIsOccupied = hit.transform.gameObject.GetComponent<Tile>().isOccupied;
                    isSameWaggon = hit.transform.gameObject.GetComponent<Tile>().waggonNumber == player.GetComponent<Player>().playerCurrentWaggon;
                    if (!fieldIsOccupied && isSameWaggon)
                    {
                        playerNextTile = hit.transform.gameObject;
                        playerNextTile.GetComponent<Tile>().isOccupied = true; 
                        playerNextPos = playerNextTile.transform.position;
                        player.GetComponent<Player>().playerCurrentWaggon = playerNextTile.GetComponent<Tile>().waggonNumber;

                    }
                }
            }

        }

        if (playerNextTile)
        {
            playerNextPos = new Vector3(playerNextPos.x, 1, playerNextPos.z);
            player.transform.position = playerNextPos;
            playerCurrentTile.GetComponent<Renderer>().material = tileTexture;
            playerCurrentTile.GetComponent<Tile>().isOccupied = false;
            playerNextTile.GetComponent<Renderer>().material = tileSelected;
            playerCurrentTile = playerNextTile;
        }
    }

    

    public CharacterData GetData()
    {
        return new CharacterData(playerCurrentPos);
    }
    //public void SetData(CharacterData data)
    //{
    //    this.transform.position = data.pos;
    //}



}


public class CharacterData
{
    public Vector3 arrayPos;
    public CharacterData(Vector3 arrayPos)
    {
        this.arrayPos = arrayPos;

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//                                              //
//                  TODO                        //
//                                              //
/*
delay camera
blocking by side walls
after turn > 90degree move body with head <-
*/

public class Player : MonoBehaviour
{

    public GameObject head;
    public GameObject logic;
    public Camera characterCamera;
    Vector3 cameraPos = new Vector3();
    public int playerCurrentWaggon;
    float cameraDistance = -11.07f;
    public List<GameObject> nearTileList = new List<GameObject>();

    void Start()
    {

    }

    void Update()
    {
        LookAtMouse();
        CameraController();
        GetNearTiles();
    }

    void LookAtMouse()
    {
        Vector3 lookTarget = new Vector3();
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            lookTarget = hit.point;
        }
        head.transform.LookAt(lookTarget);
    }

    void CameraController()
    {
        cameraPos = characterCamera.transform.position;
        cameraPos.x = cameraDistance;
        characterCamera.transform.position = cameraPos;


    }

    void GetNearTiles()
    {
        int currentTileWaggon = Logic.playerCurrentTile.GetComponent<Tile>().waggonNumber;
        int currentTileArrayPosX = Logic.playerCurrentTile.GetComponent<Tile>().tileArrayPosX;
        int currentTileArrayPosY = Logic.playerCurrentTile.GetComponent<Tile>().tileArrayPosY;
        if (currentTileArrayPosY + 1 <= Logic.tileArray.GetUpperBound(2))
        {
            nearTileList.Add(Logic.tileArray[currentTileWaggon, currentTileArrayPosX, currentTileArrayPosY+1]);
        }
        if (currentTileArrayPosY -1 >= 0)
        {
            nearTileList.Add(Logic.tileArray[currentTileWaggon, currentTileArrayPosX, currentTileArrayPosY - 1]);
        }
        if (currentTileArrayPosX + 1 <= Logic.tileArray.GetUpperBound(1))
        {
            nearTileList.Add(Logic.tileArray[currentTileWaggon, currentTileArrayPosX + 1, currentTileArrayPosY]);

            if (currentTileArrayPosY + 1 <= Logic.tileArray.GetUpperBound(2))
            {
                nearTileList.Add(Logic.tileArray[currentTileWaggon, currentTileArrayPosX + 1, currentTileArrayPosY + 1]);
            }
            if (currentTileArrayPosY - 1 >= 0)
            {
                nearTileList.Add(Logic.tileArray[currentTileWaggon, currentTileArrayPosX + 1, currentTileArrayPosY - 1]);
            }
        }
        if (currentTileArrayPosX - 1 >= 0)
        {
            nearTileList.Add(Logic.tileArray[currentTileWaggon, currentTileArrayPosX - 1, currentTileArrayPosY]);
            if (currentTileArrayPosY + 1 <= Logic.tileArray.GetUpperBound(2))
            {
                nearTileList.Add(Logic.tileArray[currentTileWaggon, currentTileArrayPosX - 1, currentTileArrayPosY + 1]);
            }
            if (currentTileArrayPosY - 1 >= 0)
            {
                nearTileList.Add(Logic.tileArray[currentTileWaggon, currentTileArrayPosX - 1, currentTileArrayPosY - 1]);
            }
        }
    }

    bool IsInSameWaggon(GameObject tile1, GameObject tile2)
    {
        if (tile1.GetComponent<Tile>().waggonNumber == tile2.GetComponent<Tile>().waggonNumber)
        {
            return true;
        }
        return false;
    }
    

    void Astar()
    {



    }

    void Pathfinding()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    public GameObject head;
    public int playerCurrentWaggon;
    public GameObject playerCurrentTile;
    public List<GameObject> nearTileList = new List<GameObject>();
    bool isCurrentPlayer = false;

    void Update()
    {
        LookAtMouse(isCurrentPlayer);
        GetNearTiles();
    }


    void LookAtMouse(bool isCurrentPlayer)
    {
        if (isCurrentPlayer)
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
    }

    void GetNearTiles()
    {
        nearTileList.Clear();
        int currentTileWaggon = playerCurrentTile.GetComponent<Tile>().waggonNumber;
        int currentTileArrayPosX = playerCurrentTile.GetComponent<Tile>().tileArrayPosX;
        int currentTileArrayPosY = playerCurrentTile.GetComponent<Tile>().tileArrayPosY;
        if (currentTileArrayPosY + 1 <= Map.tileArray.GetUpperBound(2))
        {
            nearTileList.Add(Map.tileArray[currentTileWaggon, currentTileArrayPosX, currentTileArrayPosY+1]);
        }
        if (currentTileArrayPosY -1 >= 0)
        {
            nearTileList.Add(Map.tileArray[currentTileWaggon, currentTileArrayPosX, currentTileArrayPosY - 1]);
        }
        if (currentTileArrayPosX + 1 <= Map.tileArray.GetUpperBound(1))
        {
            nearTileList.Add(Map.tileArray[currentTileWaggon, currentTileArrayPosX + 1, currentTileArrayPosY]);

            if (currentTileArrayPosY + 1 <= Map.tileArray.GetUpperBound(2))
            {
                nearTileList.Add(Map.tileArray[currentTileWaggon, currentTileArrayPosX + 1, currentTileArrayPosY + 1]);
            }
            if (currentTileArrayPosY - 1 >= 0)
            {
                nearTileList.Add(Map.tileArray[currentTileWaggon, currentTileArrayPosX + 1, currentTileArrayPosY - 1]);
            }
        }
        if (currentTileArrayPosX - 1 >= 0)
        {
            nearTileList.Add(Map.tileArray[currentTileWaggon, currentTileArrayPosX - 1, currentTileArrayPosY]);
            if (currentTileArrayPosY + 1 <= Map.tileArray.GetUpperBound(2))
            {
                nearTileList.Add(Map.tileArray[currentTileWaggon, currentTileArrayPosX - 1, currentTileArrayPosY + 1]);
            }
            if (currentTileArrayPosY - 1 >= 0)
            {
                nearTileList.Add(Map.tileArray[currentTileWaggon, currentTileArrayPosX - 1, currentTileArrayPosY - 1]);
            }
        }
    }
}

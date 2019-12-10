using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public static List<GameObject> PrefabCharList = new List<GameObject>();
    public static List<GameObject> charList = new List<GameObject>();
    public Material tileTexture;
    public Material tileSelected;
    public static int currentSelectedChar = 0;
    public static GameObject currentPlayer;

    GameObject playerNextTile;
    Vector3 playerNextPos = new Vector3();

    public bool isSameWaggon;

    // camera stuff //
    public Camera characterCamera;
    float cameraDistance = -11.07f;

    void Start()
    {
        SetCurrentPlayer(currentSelectedChar);
    }
	
	void Update ()
    {
        SetCurrentPlayer(currentSelectedChar);
        if (!SwitchPlayer.playerMenuIsActive && !EscapeMenu.escapeMenuIsActive)
        {
            MovePlayer(currentPlayer);
        }
        CameraController();
    }

    void SetCurrentPlayer(int currentSelectedChar)
    {
        currentPlayer = charList[currentSelectedChar];
    }



    void MovePlayer(GameObject currentPlayer)
    {
        if (Global.rightClik)
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
                    isSameWaggon = hit.transform.gameObject.GetComponent<Tile>().waggonNumber == currentPlayer.GetComponent<Player>().playerCurrentWaggon;
                    if (!fieldIsOccupied && isSameWaggon)
                    {
                        playerNextTile = hit.transform.gameObject;
                        playerNextTile.GetComponent<Tile>().isOccupied = true;
                        playerNextPos = playerNextTile.transform.position;
                        currentPlayer.GetComponent<Player>().playerCurrentWaggon = playerNextTile.GetComponent<Tile>().waggonNumber;

                    }
                }
            }

        }
        if (playerNextTile)
        {
            playerNextPos = new Vector3(playerNextPos.x, 1, playerNextPos.z);
            currentPlayer.transform.position = playerNextPos;
            currentPlayer.GetComponent<Player>().playerCurrentTile.GetComponent<Renderer>().material = tileTexture;
            currentPlayer.GetComponent<Player>().playerCurrentTile.GetComponent<Tile>().isOccupied = false;
            playerNextTile.GetComponent<Renderer>().material = tileSelected;
            currentPlayer.GetComponent<Player>().playerCurrentTile = playerNextTile;
        }
    }

    void CameraController()
    {
        Vector3 cameraPos = new Vector3(cameraDistance, currentPlayer.transform.position.y + 7, currentPlayer.transform.position.z);
        characterCamera.transform.position = cameraPos;

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class PlayerLogic : MonoBehaviour
{
    public static List<GameObject> PrefabCharList = new List<GameObject>();
    public static List<GameObject> charList = new List<GameObject>();
    public Material tileTexture;
    public Material tileSelected;
    public static int currentSelectedChar = 0;
    public static GameObject currentPlayer;
    int coroutine = 1;
    float triggerDistance = 0.1f;
    float distance = 0f;
    public static bool isMoving = false;



    public bool isSameWaggon;

    // camera stuff //
    public Camera characterCamera;
    float cameraDistance = -11.07f;

    //shake
    public float decreaseFactor = 1.0f;
    int timeDuration = 0;
    Vector3 originalPos;
    static float time;
    float waitSecTime;
    bool shake = false;
    bool secondPassed = false;

    void Start()
    {
        SetCurrentPlayer(currentSelectedChar);
        timeDuration = UnityEngine.Random.Range(5, 20);
        characterCamera.transform.localPosition = new Vector3(cameraDistance, currentPlayer.transform.position.y + 7, currentPlayer.transform.position.z);
    }

    void Update()
    {
        SetCurrentPlayer(currentSelectedChar);

        if (!SwitchPlayer.playerMenuIsActive && !EscapeMenu.escapeMenuIsActive)
        {
            MovePlayer(currentPlayer);
        }
    }

    void SetCurrentPlayer(int currentSelectedChar)
    {
        currentPlayer = charList[currentSelectedChar];
    }


    #region movement
    void MovePlayer(GameObject currentPlayer)
    {
        if (Global.rightClik)
        {
            if (!isMoving)
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                int raylenght = 2000;
                Debug.DrawRay(ray.origin, ray.direction, Color.green);

                if (Physics.Raycast(ray, out hit, raylenght))
                    if (Physics.Raycast(ray, out hit, raylenght))
                    {
                        if (hit.transform.gameObject.name.Contains("Tile"))
                        {
                            bool fieldIsOccupied = hit.transform.gameObject.GetComponent<Tile>().isOccupied;
                            isSameWaggon = hit.transform.gameObject.GetComponent<Tile>().waggonNumber == currentPlayer.GetComponent<Player>().playerCurrentWaggon;
                            if (!fieldIsOccupied && isSameWaggon)
                            {
                                List<Vector3> path = CreatePathOnGrid(currentPlayer.GetComponent<Player>().playerCurrentTile, hit.transform.gameObject);
                                if (path != null)
                                {
                                    StartCoroutine(RunPath(path, currentPlayer));
                                }
                            }
                        }
                    }

            }
        }
    }


    void ShakeCamera()
    {
        time += Time.deltaTime;
        if (!shake)
        {
            characterCamera.transform.localPosition = new Vector3(cameraDistance, currentPlayer.transform.position.y + 7, currentPlayer.transform.position.z);
        }

        if (time > timeDuration && !shake)
        {
            shake = true;
            secondPassed = false;
            waitSecTime = time + 2;
            timeDuration = UnityEngine.Random.Range(5, 20);
            originalPos = new Vector3(cameraDistance, currentPlayer.transform.position.y + 7, currentPlayer.transform.position.z);
        }

        if (shake && time > waitSecTime)
        {
            secondPassed = true;
            shake = false;
            time = 0;
            characterCamera.transform.localPosition = originalPos;
        }

        if (shake && !secondPassed)
        {
            characterCamera.transform.localPosition = originalPos + UnityEngine.Random.insideUnitSphere * 0.08f;
        }
    }

    #endregion

    #region Pathfinding

    //Neuhaus
    public static int Distance(GameObject start, GameObject end)
    {
        float dist = 0;
        float xDist = Mathf.Abs(end.transform.position.x - start.transform.position.x);
        float yDist = Mathf.Abs(end.transform.position.y - start.transform.position.y);
        if (xDist >= yDist) // die kürzere Seite bekommt 4 zusätzliche
        {
            dist = (4 * yDist) + (10 * xDist);
        }
        else
        {
            dist = (4 * xDist) + (10 * yDist);
        }

        return (int)dist;
    }

    //Neuhaus
    public List<Vector3> CreatePathOnGrid(GameObject start, GameObject target)
    {
        int maxSteps = 250;

        List<Vector3> path = new List<Vector3>();

        GameObject toCheck = start;
        List<GameObject> foundPath = new List<GameObject>();
        List<GameObject> toSearchTiles = new List<GameObject>();
        List<GameObject> searchedTiles = new List<GameObject>();

        toSearchTiles.Add(toCheck);

        for (int i = 0; i < maxSteps; i++)
        {
            //https://youtu.be/mZfyt03LDH4?t=1009
            toCheck = toSearchTiles[0];

            foreach (var item in toSearchTiles)
            {
                if (item.GetComponent<Tile>().sumCost < toCheck.GetComponent<Tile>().sumCost ||
                   ((item.GetComponent<Tile>().sumCost == toCheck.GetComponent<Tile>().sumCost) &&
                   (item.GetComponent<Tile>().toCost < toCheck.GetComponent<Tile>().toCost)))
                {
                    toCheck = item;
                }
            }

            if (toCheck == target)
            {
                break; // yipiee, fertig
            }

            toSearchTiles.Remove(toCheck);
            searchedTiles.Add(toCheck);

            foreach (var item in Logic.getNearTiles(toCheck))
            {
                if (item != null)
                {
                    if (!item.GetComponent<Tile>().isOccupied)
                    {


                        if (searchedTiles.Contains(item))
                        {
                            continue;
                        }
                        int thisStepCost = toCheck.GetComponent<Tile>().fromCost + Distance(toCheck, item);
                        if (!toSearchTiles.Contains(item) || thisStepCost < item.GetComponent<Tile>().fromCost)
                        {
                            item.GetComponent<Tile>().predecessor = toCheck;
                            item.GetComponent<Tile>().fromCost = item.GetComponent<Tile>().predecessor.GetComponent<Tile>().fromCost + Distance(item, item.GetComponent<Tile>().predecessor);
                            item.GetComponent<Tile>().toCost = Distance(item, target);
                            item.GetComponent<Tile>().sumCost = item.GetComponent<Tile>().fromCost + item.GetComponent<Tile>().toCost;
                            if (!toSearchTiles.Contains(item))
                            {
                                toSearchTiles.Add(item);
                            }
                        }
                    }
                }
            }
        }

        GameObject addTile = target;
        for (int i = 0; i < maxSteps; i++)
        {
            if (addTile == start)
            {
                break;
            }
            addTile.GetComponent<Renderer>().material = tileSelected;
            Vector3 adjustedPos = new Vector3(addTile.transform.position.x, 1, addTile.transform.position.z);
            path.Add(adjustedPos);
            addTile = addTile.GetComponent<Tile>().predecessor;
        }
        Vector3 adjustedStartPos = new Vector3(start.transform.position.x, 1, start.transform.position.z);
        path.Add(adjustedStartPos);
        path.Reverse();
        return path;
    }

    IEnumerator RunPath(List<Vector3> path, GameObject currentPlayer)
    {
        Vector3 start = path[0];
        while (coroutine < path.Count)
        {
            isMoving = true;
            currentPlayer.transform.LookAt(path[coroutine]);
            distance += Time.deltaTime / Vector3.Distance(currentPlayer.transform.position, path[coroutine]);
            currentPlayer.transform.position = Vector3.Lerp(start, path[coroutine], Mathf.SmoothStep(0.0f, 1.0f, distance));

            if (Vector3.Distance(currentPlayer.transform.position, path[coroutine]) < triggerDistance)
            {
                //set tile states etc
                GameObject nextTile = Map.Vector3ToTile(currentPlayer.GetComponent<Player>().playerCurrentWaggon, (int)path[coroutine].x, (int)path[coroutine].z);
                currentPlayer.GetComponent<Player>().playerCurrentTile.GetComponent<Tile>().isOccupied = false;
                currentPlayer.GetComponent<Player>().playerCurrentTile.GetComponent<Renderer>().material = tileTexture;
                nextTile.GetComponent<Tile>().isOccupied = true;
                nextTile.GetComponent<Renderer>().material = tileSelected;
                currentPlayer.GetComponent<Player>().playerCurrentTile = nextTile;

                distance = 0;
                start = path[coroutine];
                coroutine++;
            }
            yield return null;
        }
        Debug.Log("Coroutine abgearbeitet");
        isMoving = false;
        coroutine = 0;
        path.Clear();
    }

    #endregion
}

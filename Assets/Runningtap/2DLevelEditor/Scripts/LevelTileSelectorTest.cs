using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runningtap
{
    //shitcode to get placement and storage prototyped

    public class LevelTileSelectorTest : MonoBehaviour
    {
        public GameObject Level;

        public int objectType;
        public GameObject[] TilePallete;

        private LevelData levelData;
        private int currentSelection;

        public GameObject pointSprite;

        private bool movingTile;

        private int currentPallete;
        private int setState;

        [System.Serializable]
        public class TileGroupSet
        {
            public string TileGroupName;
            public GameObject[] TileObjects;

        }

        public TileGroupSet[] tileGroupSet;

        public GameObject player;
        int playerX;
        int playerY;
        bool playerSet;

        public enum Mode
        {
            Paint,
            Erase,
            Move,
            Set

        }
        [HideInInspector]
        public Mode cursorMode = Mode.Paint;

        private void Start()
        {
            levelData = GetComponent<LevelData>();

            currentPallete = 0;
            TilePallete = new GameObject[tileGroupSet[currentPallete].TileObjects.Length];
            for(int i = 0; i< TilePallete.Length; i++)
            {
                TilePallete[i] = tileGroupSet[currentPallete].TileObjects[i];
            }


        }

        private void OnEnable()
        {
            LevelGridCursor.TilePlacement += PlaceTile;
        }

        private void OnDisable()
        {
            LevelGridCursor.TilePlacement -= PlaceTile;
        }

        public void SetBrushMode(int mode)
        {
            if (mode == 0)
                cursorMode = Mode.Paint;
            else if (mode == 1)
                cursorMode = Mode.Erase;
            else if (mode == 2)
                cursorMode = Mode.Move;
            else if (mode == 3)
                cursorMode = Mode.Set;
        }

        public void SelectRune(int index)
        {
            currentSelection = index;
        }

        public void ClearGrid()
        {
            player = null;
            foreach(GameObject[] x in levelData.xy)
            {
                foreach(GameObject y in x)
                {
                    Destroy(y);
                }
            }
        }

        bool IsCellEmpty(int x, int y)
        {
            return (levelData.xy[x][y] == null) ? true : false;
        }

        public void PlaceTile(Vector3 position)
        {
            int x = Mathf.RoundToInt(position.x);
            int y = Mathf.RoundToInt(position.y);

            if (cursorMode == Mode.Paint)
            {
                

                if (IsCellEmpty(x, y))
                {
                    var obj = Instantiate(TilePallete[currentSelection], position, Quaternion.identity, Level.transform);
                    levelData.xy[x][y] = obj;
                    if (obj.CompareTag("Player"))
                    {
                        if(player == null)
                        {
                            player = obj;
                            playerX = x;
                            playerY = y;
                        }
                        else
                        {
                            Destroy(player);
                            Destroy(levelData.xy[playerX][playerY]);
                            player = obj;
                            
                        }
                       

                    }

                }
                else if (levelData.xy[x][y] != TilePallete[currentSelection])
                {
                    Destroy(levelData.xy[x][y]);
                    var obj = Instantiate(TilePallete[currentSelection], position, Quaternion.identity, Level.transform);
                    levelData.xy[x][y] = obj;

                    if (obj.CompareTag("Player"))
                    {
                        if (player != null)
                        {
                            Destroy(player);
                            Destroy(levelData.xy[playerX][playerY]);
                            player = obj;
                            return;
                        }
                        else if (player == null)
                        {
                            player = obj;
                            playerX = x;
                            playerY = y;
                            return;
                        }
                    }

                }
                
                
            }
            else if (cursorMode == Mode.Erase)
            {
                Destroy(levelData.xy[x][y]);
                levelData.xy[x][y] = null;
            }
            else if (cursorMode == Mode.Move && !movingTile)
            {
                if (!IsCellEmpty(x, y))
                {
                    StartCoroutine(MoveTile(levelData.xy[x][y], x, y));
                    levelData.xy[x][y].SetActive(false);
                }
            }
            else if(cursorMode == Mode.Set)
            {
                if (IsCellEmpty(x, y))
                {
                    levelData.xy[x][y] = Instantiate(pointSprite, position, Quaternion.identity, Level.transform);
                    setState++;
                    if(setState == 3)
                    {
                        cursorMode = Mode.Paint;
                        setState = 0;
                    }
                }
            }

        }

        public void SetTileType(bool value)
        {

            if (value)
            {
                if(currentPallete == tileGroupSet.Length)
                { return; }
                else
                {
                    currentPallete++;

                }
            }
            else
            {
                if(currentPallete == 0) { return; }
                else
                {
                    currentPallete--;

                }
            }
           

            TilePallete = new GameObject[tileGroupSet[currentPallete].TileObjects.Length];
            for (int i = 0; i < TilePallete.Length; i++)
            {
                TilePallete[i] = tileGroupSet[currentPallete].TileObjects[i];
            }
        }
        

        public IEnumerator MoveTile(GameObject tile, int x, int y)
        {
            movingTile = true;

            while (Input.GetMouseButton(0))
            {
                yield return new WaitForEndOfFrame();
            }

            if (!IsCellEmpty(LevelGridCursor.CursorCurrentX, LevelGridCursor.CursorCurrentY))
            {
                levelData.xy[x][y].SetActive(true);
                movingTile = false;
                yield return null;
            }
            else
            {
                int newX = LevelGridCursor.CursorCurrentX;
                int newY = LevelGridCursor.CursorCurrentY;
                tile.SetActive(true);
                tile.transform.position = new Vector3(newX, newY, transform.position.z);
                levelData.xy[newX][newY] = tile;
                levelData.xy[x][y] = null;

                movingTile = false;
                yield return null;
            }
        }

        public void StartPlay()
        {
            //if (!playerSet) { return; }
            //if(levelData.Player == null) { return; }

            levelData.SetPlayer(true);

        }
    }
}
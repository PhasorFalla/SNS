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
        public GameObject[] TileGroup;

        private LevelData levelData;
        private int currentSelection;

        public GameObject pointSprite;

        private bool movingTile;

        private int currentPallete;
        private int setState;


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

            var group = TileGroup[currentPallete].GetComponent<UITileGroupSet>();

            TilePallete = new GameObject[group.TileObjects.Length];

            for (int i = 0; i < group.TileObjects.Length; i++)
            {
                TilePallete[i] = group.TileObjects[i];
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
                //if (TilePallete[currentSelection].gameObject.CompareTag("Player"))
                //{
                //    if (IsCellEmpty(x, y))
                //    {
                //        playerSet = true;
                //    }

                //    if(!IsCellEmpty(x, y))
                //    {
                //        Destroy(levelData.xy[x][y]);
                //        levelData.xy[x][y] = Instantiate(TilePallete[currentSelection], position, Quaternion.identity, Level.transform);
                //    }
                //}


                if (IsCellEmpty(x, y))
                {
                    levelData.xy[x][y] = Instantiate(TilePallete[currentSelection], position, Quaternion.identity, Level.transform);

                }
                else if (levelData.xy[x][y] != TilePallete[currentSelection])
                {
                    Destroy(levelData.xy[x][y]);
                    levelData.xy[x][y] = Instantiate(TilePallete[currentSelection], position, Quaternion.identity, Level.transform);

                }

                //if(currentSelection == 3)
                //{
                //    cursorMode = Mode.Set;

                //}
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
                currentPallete = 0;


            }
            else
            {
                currentPallete = 1;

            }

            var group = TileGroup[currentPallete].GetComponent<UITileGroupSet>();

            TilePallete = new GameObject[group.TileObjects.Length];

            for(int i = 0; i< group.TileObjects.Length; i++)
            {
                TilePallete[i] = group.TileObjects[i];
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
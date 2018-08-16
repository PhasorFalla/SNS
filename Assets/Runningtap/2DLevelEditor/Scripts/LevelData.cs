using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runningtap
{
    public class LevelData : MonoBehaviour
    {
        public GameObject Player;

        public GameObject[][] xy;
        public LevelGrid Grid;
        public GameObject editorPanel;

        private void Start()
        {
            CreateEmptyCoordingates(Grid.X, Grid.Y);
        }

        public void CreateEmptyCoordingates(int x, int y)
        {
            xy = new GameObject[x][];

            for (int xi = 0; xi < x; xi++)
            {
                xy[xi] = new GameObject[y];

                for (int yi = 0; yi < y; yi++)
                {
                    xy[xi][yi] = null;
                }
            }
        }

        public void SetPlayer(bool state)
        {
            

            if(GameObject.FindGameObjectsWithTag("Player").Length > 1) { print("Too Many"); return; }
            Player = GameObject.FindGameObjectWithTag("Player");

            if (state)
            {
                Player.GetComponent<Rigidbody2D>().gravityScale = 1;
                Player.GetComponent<Movement>().enabled = true;
                Player.GetComponent<Grapple>().enabled = true;
                EditorOut();
            }
        }

        public void EditorOut()
        {
            Grid.gameObject.SetActive(false);
            GetComponent<LevelTileSelectorTest>().enabled = false;
            Camera.main.GetComponent<CameraClickDrag>().enabled = false;
            Camera.main.GetComponent<CameraRubberBand>().enabled = false;
            Camera.main.GetComponent<CameraFollower>().target = Player.transform;
            Camera.main.GetComponent<CameraFollower>().enabled = true;
            editorPanel.SetActive(false);
            this.enabled = false;

        }
    }
}
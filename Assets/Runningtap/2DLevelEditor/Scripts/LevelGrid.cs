using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Runningtap
{
    public class LevelGrid : MonoBehaviour
    {
        [SerializeField]
        private int x, y;


        [HideInInspector]
        public int xMinValue = 1;
        [HideInInspector]
        public int xMaxValue = 25;
        [HideInInspector]
        public int yMinValue = 1;
        [HideInInspector]
        public int yMaxValue = 25;

        public Text xValue;
        public Text yValue;


        public bool Debug;

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }

        private void Awake()
        {
            GetComponent<LevelGridVisual>().UpdateGridVisual(x, y);
                UpdateText();

        }

        public void UpdateText()
        {
            xValue.text = x.ToString();
            yValue.text = y.ToString();
        }

        public void UpdateGridX(bool value)
        {
            if (value)
            {

                if(x < xMaxValue)
                {
                    x++;
                    GetComponent<LevelGridVisual>().UpdateGridVisual(x, y);
                    UpdateText();
                }
                else { return; }
                


            }
            else
            {
                if(x > xMinValue)
                {
                    x--;
                    GetComponent<LevelGridVisual>().UpdateGridVisual(x, y);
                    UpdateText();

                }
                else { return; }
            }
            
        }

        public void UpdateGridY(bool value)
        {
            if (value)
            {
                if (y < yMaxValue)
                {
                    y++;
                    GetComponent<LevelGridVisual>().UpdateGridVisual(x, y);
                    UpdateText();
                }
                else { return; }

            }
            else
            {
                if (y > yMinValue)
                {
                    y--;
                    GetComponent<LevelGridVisual>().UpdateGridVisual(x, y);
                    UpdateText();
                }
                else
                {
                    return;
                }
            }
        }


        public Vector3 GetNearestPointOnGrid(Vector3 position)
        {
            position -= transform.position;

            int x = Mathf.RoundToInt(position.x);
            int y = Mathf.RoundToInt(position.y);
            int z = Mathf.RoundToInt(position.z);

            return new Vector3(x, y, z) + transform.position;
        }

        private void OnDrawGizmos()
        {
            if (Debug)
            {
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        var point = GetNearestPointOnGrid(new Vector3(i, j, 0f));
                        Gizmos.DrawWireCube(point, new Vector3(0.9f, 0.9f, 0f));
                    }
                }
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public Transform[] path;
    public float speed = 5.0f;
    public float reachDist = 1.0f;
    public int targetIndex = 0;

    private Transform target;
    private int ArrayDirection = 1;
    public bool arrived;
    bool isPaused;

    void Start ()
    {
        StartCoroutine(MoveToPoint(path[0]));
    }
	
	void Update ()
    {
        
        for (int i = 1; i < path.Length; i++)
        {
            Debug.DrawLine(path[i].position, path[i - 1].position, Color.yellow);
        }
    }

    public void SetNextPoint()
    {
        if (targetIndex >= path.Length - 1)
        {
            ArrayDirection = -1;
        }
        else if (targetIndex <= 0)
        {
            ArrayDirection = 1;
        }

        targetIndex += ArrayDirection;
        target = path[targetIndex];
        arrived = false;
        StartCoroutine(MoveToPoint(target));
    }

    IEnumerator MoveToPoint(Transform point)
    {
        while (!arrived)
        {
            transform.position = Vector3.MoveTowards(transform.position, point.position, speed / 100f);

            if (Vector3.Distance(transform.position, point.position) < 0.1)
            {
                arrived = true;
                SetNextPoint();
                yield break;
            }
            yield return new WaitForEndOfFrame();
        }
    }

}

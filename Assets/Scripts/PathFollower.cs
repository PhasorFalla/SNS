using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour {

    public Transform[] path;
    public float speed = 5.0f;
    public float reachDist = 1.0f;
    public int targetIndex = 0;
    

    public bool arrived;
    public bool flip;
    private Transform target;

    private int ArrayDirection = 1;
    bool flipped;

    private void Start()
    {
        flipped = false;
        StartCoroutine(MoveToPoint(path[0]));
    }

    private void Update()
    {
        for(int i = 1; i < path.Length; i++)
        {
            Debug.DrawLine(path[i].position, path[i-1].position, Color.yellow);
        }
    }

    public void SetNextPoint()
    {
        if(targetIndex >= path.Length - 1)
        {
            ArrayDirection = -1;
        }

        else if(targetIndex <= 0)
        {
            ArrayDirection = 1;
        }

        targetIndex += ArrayDirection;
        target = path[targetIndex];
        arrived = false;
        StartCoroutine(MoveToPoint(target));
    }

    public void FlipFish()
    {
        if (!flip) { return; }
        float i = 0;
        if (flipped)
        {
            i = -1;
            flipped = false;
        }
        else
        {
            i = 1;
            flipped = true;
        }
        
        gameObject.transform.localScale = new Vector3(i, 1, 1);
    }

    IEnumerator MoveToPoint(Transform point)
    {
        while(!arrived)
        {
            transform.position = Vector3.MoveTowards(transform.position, point.position, speed / 100f);

            if (Vector3.Distance(transform.position, point.position) < 0.1)
            {
                arrived = true;
                FlipFish();
                SetNextPoint();
                yield break;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
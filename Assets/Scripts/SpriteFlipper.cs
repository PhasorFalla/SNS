using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour {

    private Vector3 PrevPos;
    float y;

    private void Start()
    {
        PrevPos = transform.position;
    }
    
    void Update ()
    {
        
        if (transform.position.x < PrevPos.x) 
        {
            y = 0;
        }
        else
        {
           y = 180;
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, y, 0));
        PrevPos = transform.position;
   	}
}

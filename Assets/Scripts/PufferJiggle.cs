using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PufferJiggle : MonoBehaviour {

    public float jiggle = 1;
    public float amplitude = 5;
    private float offset;

    private void Start()
    {
        offset = transform.rotation.z; 
    }
  
    void Update ()
    {
        float jiggles = (Mathf.PingPong(offset + Time.time * jiggle, amplitude)) - (amplitude / 2);

        Vector3 rotation = new Vector3(transform.rotation.x, transform.rotation.y, jiggles);

        transform.rotation = Quaternion.Euler(rotation);
   	}
}

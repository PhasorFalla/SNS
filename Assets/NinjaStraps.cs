using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStraps : MonoBehaviour
{
    public GameObject player;
    public float smooth = 5.0f;
    public GameObject[] straps;
    public float strapMovement;

    [HideInInspector]
    public bool moving;
    float angle;
    Rigidbody2D rb;

    private void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        strapMovement = straps[0].GetComponent<Cloth>().worldVelocityScale;
    }

    void Update()
    {
        if(rb == null || rb.velocity.x == 0 && rb.velocity.y == 0) { return; }
        Vector2 dir = rb.velocity;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * smooth);


        if (!moving)
        {
            foreach (GameObject cloth in straps)
            {
                cloth.GetComponent<Cloth>().worldVelocityScale = 0;
            }
        }
        else
        {
            foreach (GameObject cloth in straps)
            {
                cloth.GetComponent<Cloth>().worldVelocityScale = strapMovement;
            }
        }
            
    }
}

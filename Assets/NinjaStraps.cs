using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStraps : MonoBehaviour
{
    public GameObject player;

    public float smooth = 5.0f;

    Rigidbody2D rb;

    private void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(rb == null) { return; }
        Vector2 dir = rb.velocity;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * smooth);

    }
}

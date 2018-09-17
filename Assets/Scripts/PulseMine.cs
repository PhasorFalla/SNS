using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseMine : MonoBehaviour
{
    public GameObject target;
    public float collisionDst;
    public float radius;
    public float power;
    bool player;

    private void Start()
    {
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawWireSphere(transform.position, collisionDst);
    }

    void Update ()
    {
        if(target == null) { return; }
        float dst = Vector3.Distance(transform.position, target.transform.position);

        if(dst < collisionDst)
        {
            Pulse();
        }

        
	}

    public void Pulse()
    {
        if(target == null) { return; }

        if(player == false) { return; }
        Rigidbody2D rb = target.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * power);


    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = false;
        }
    }



    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("hit");
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseMine : MonoBehaviour
{
    private GameObject target;
    public float collisionDst;
    public float power;
    bool player;

    private void Start()
    {
        player = FanReset.deathzone.player;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
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
        //rb.AddForce(transform.up * power);
        rb.AddForce((target.transform.position - transform.position).normalized * power);

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



 

}

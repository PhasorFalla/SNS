using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vents : MonoBehaviour
{
    public float power;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * power);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerTrig : MonoBehaviour
{
    public GameObject popUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            popUp.SetActive(true);

        }
    }
}

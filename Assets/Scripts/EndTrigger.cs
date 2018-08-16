using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTrigger : MonoBehaviour
{
    public Transform Canvas;
    private bool EndResults;

    private void Start()
    {
        EndResults = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}

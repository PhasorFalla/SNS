using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCanvas : MonoBehaviour
{
    public GameObject canvasPanel;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canvasPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

}

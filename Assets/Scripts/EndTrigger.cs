using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTrigger : MonoBehaviour
{
    public ParticleSystem[] fireworks;
    public GameObject resultCanvas;
    public bool endTrigger;
    private bool endResults;

    private void Start()
    {
        endResults = false;
    }

    

    public void TriggerFireworks()
    {
        if(fireworks.Length < 1 || fireworks[0] == null) { return; }
        foreach(ParticleSystem firework in fireworks)
        {
            firework.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (endResults) { return; }

        if (collision.gameObject.CompareTag("Player"))
        {
            if (!endTrigger)
            {
                TriggerFireworks();

            }
            else
            {
                resultCanvas.SetActive(true);
                endResults = true;
                Time.timeScale = 0f;
            }
        }
    }

}

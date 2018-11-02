using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTrigger : MonoBehaviour
{
    public ParticleSystem[] fireworks;
    public GameObject resultCanvas;
    public GameObject backgroundBubbles;
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

    public void EndLevel()
    {
        Camera.main.orthographicSize = 7f;
        Camera.main.GetComponent<CameraFollower>().enabled = false;
        resultCanvas.SetActive(true);
        backgroundBubbles.SetActive(true);
        endResults = true;
        FanReset.deathzone.finished = true;
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
                EndLevel();
                
            }
        }
    }

}

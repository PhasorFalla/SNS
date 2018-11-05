﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTrigger : MonoBehaviour
{
    public ParticleSystem[] fireworks;
    public GameObject resultCanvas;
    public GameObject backgroundBubbles;

    public Transform start;
    public Transform end;

    public float randomStart;
    public float randomEnd;

    public bool endTrigger;
    private bool endResults;

    private void Start()
    {
        endResults = false;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        if (!endTrigger)
        {
            Gizmos.DrawLine(start.position, end.position);

        }

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
                StartCoroutine(FireworkTimer());

            }
            else
            {
                EndLevel();
                
            }
        }
    }

    public IEnumerator FireworkTimer()
    {
        //var time = Random.Range(randomStart, randomEnd);

        for(int i = 0; i< fireworks.Length; i++)
        {
            var time = Random.Range(randomStart, randomEnd);
            Vector3 pos = new Vector3(Random.RandomRange(start.position.x, end.position.x), transform.position.y, transform.position.z);
            yield return new WaitForSeconds(time);
            ParticleSystem boom = Instantiate(fireworks[i], pos, transform.rotation);
            boom.Play();
            boom = null;
        }

        yield return new WaitForSeconds(5f);
        StartCoroutine(FireworkTimer());

        yield break;
    }

}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTrig : MonoBehaviour
{

    public GameObject selectionCanvas;

    public void LoadScene(string scene)
    {

        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
    }

    public void ResetScene()
    {

        SceneManager.LoadScene("Start");
        Time.timeScale = 1f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            selectionCanvas.SetActive(true);
        }
    }
}

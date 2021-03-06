﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Transform canvas;
    public bool isPaused;
    public GameObject GameWorldSource;
    public GameObject currentGameWorld;

    public static GameController gameController;

    private void Awake()
    {
        gameController = this;
        ResetScene();
    }

    void Update ()
    {
        if (FanReset.deathzone.finished == true) { return; }
        if (Input.GetKeyDown (KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause() 
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void LoadScene(string name)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(name);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResetScene()
    {
        if (GameWorldSource == null) { return; }
        Destroy(currentGameWorld);
        var clone = Instantiate(GameWorldSource, Vector3.zero, Quaternion.identity);
        currentGameWorld = clone;
    }
}
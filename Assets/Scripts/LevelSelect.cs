using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public KeyCode back;

    bool selecting;

    public void Update()
    {
        if (Input.GetKeyDown(back))
        {
            if (!selecting)
            {
                LoadScene("StartMenuTest");
            }
        }
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}

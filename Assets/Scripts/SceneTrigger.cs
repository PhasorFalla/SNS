using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1f;
    }


}

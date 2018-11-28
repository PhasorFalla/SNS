using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FabricMusic : MonoBehaviour
{
    private void Awake()
    {
        Fabric.EventManager.Instance.PostEvent("Music/Main");
    }
}

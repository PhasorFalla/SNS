using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleStraps : MonoBehaviour {

    public GameObject Player;

    private void Start()
    {
        Fabric.EventManager.Instance.PostEvent("Music/Start", Camera.main.gameObject);
    }

    public void Update()
    {
        var pos = new Vector3(Player.transform.position.x, Player.transform.position.y, 0);
        transform.position = pos;
    }
}

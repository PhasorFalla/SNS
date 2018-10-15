using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtMouse : MonoBehaviour {

    public LineRenderer line;

	void Update ()
    {
        var mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var angle = Mathf.Atan2((mouse.y - transform.position.y), (mouse.x - transform.position.x)) / (Mathf.PI / 180);
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}

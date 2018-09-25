using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingTexture : MonoBehaviour
{

    public float speed;
    public Vector2 offset;

    private Material mat;
    private const string tex = "_MainTex";

    void Start()
    {

        mat = GetComponent<SpriteRenderer>().material;

    }

    void Update()
    {
        var x = offset.x += Time.deltaTime * speed;
        var y = offset.y ;

        mat.SetTextureOffset(tex, new Vector2(x, y));

    }

}

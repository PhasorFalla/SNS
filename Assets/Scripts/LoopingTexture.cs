﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoopingTexture : MonoBehaviour
{

    public float speed;
    public Vector2 offset;
    public bool sprite;
    private Material mat;
    private const string tex = "_MainTex";

    void Start()
    {
        if (sprite)
        {
            mat = GetComponent<SpriteRenderer>().material;

        }
        else
        {
            mat = GetComponent<Image>().material;

        }

    }

    void Update()
    {
        var x = offset.x += Time.deltaTime * speed;
        var y = offset.y ;

        mat.SetTextureOffset(tex, new Vector2(x, y));

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoopingTexture : MonoBehaviour
{

    public float speed;
    public Vector2 offset;
    private Material mat;
    private const string tex = "_MainTex";

    void Start()
    {
        if (gameObject.GetComponent<SpriteRenderer>() != null)
        {
            mat = GetComponent<SpriteRenderer>().material;

        }
        else if (gameObject.GetComponent<Image>() != null)
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

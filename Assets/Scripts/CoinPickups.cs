using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickups : MonoBehaviour
{

    public GameObject CoinVFX;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(CoinVFX, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            ScoreManager.scoreManager.CollectCoin();
            Fabric.EventManager.Instance.PostEvent("Misc/CoinCollect", Camera.main.gameObject);

            Destroy(gameObject);
        }
    }
}

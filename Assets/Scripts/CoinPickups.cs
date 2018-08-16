using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickups : MonoBehaviour
{

    public GameObject CoinVFX;
    public AudioClip coinCollectSFX;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(CoinVFX, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            ScoreManager.scoreManager.CollectCoin();

            if (coinCollectSFX != null)
            {
                AudioManager.audioManager.PlaySound(coinCollectSFX);
            }

            Destroy(gameObject);
        }
    }
}

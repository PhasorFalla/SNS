using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FanReset : MonoBehaviour {

    public Transform spawnpoint;
    public static FanReset deathzone;
    public AudioClip playerDeathSFX;
    private GameObject entityToReset;
    public GameController GC;

    [HideInInspector]
    public bool dead;

    private void Awake()
    {
        if(deathzone == null)
        {
            deathzone = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            entityToReset = collision.gameObject;
            ResetEntity(entityToReset);
        }
    }

    public void ResetEntity(GameObject entity)
    {
        GC.ResetScene();
        if(playerDeathSFX != null)
        {
            AudioManager.audioManager.PlaySound(playerDeathSFX);
        }

        if(entity.GetComponent<Rigidbody2D>() != null)
        {
            entity.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        dead = true;
        ScoreManager.scoreManager.DeathCount();
        entity.transform.position = spawnpoint.position;
    }

    
}

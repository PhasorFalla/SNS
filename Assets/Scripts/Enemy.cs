using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip deathSFX;
    public GameObject deathVFX;

    private void Start()
    {
        gameObject.tag = "Enemies";
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (other.gameObject.GetComponent<Grapple>().tethered)
            {
                other.gameObject.GetComponent<Grapple>().Detatch();
                FanReset.deathzone.ResetEntity(other.gameObject);

            }
            else
            {

                EnemyDeath();
            }




        }
    }

    public void EnemyDeath()
    {
        if(deathSFX != null)
        {
            AudioManager.audioManager.PlaySound(deathSFX);
        }
        Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    
}

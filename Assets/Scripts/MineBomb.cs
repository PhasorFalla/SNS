using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBomb : MonoBehaviour
{
    public AudioClip mineBombSFX;

    bool triggered;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !triggered)
        {
            FanReset.deathzone.ResetEntity(collision.gameObject);
            triggered = true;
            if(mineBombSFX != null) { AudioManager.audioManager.PlaySound(mineBombSFX); }
            StartCoroutine(bombResetTimer());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !triggered)
        {
            FanReset.deathzone.ResetEntity(collision.gameObject);
            triggered = true;
            if (mineBombSFX != null) { AudioManager.audioManager.PlaySound(mineBombSFX); }
            StartCoroutine(bombResetTimer());
        }
    }


    IEnumerator bombResetTimer()
    {
        yield return new WaitForSeconds(3);

        triggered = false;
    }
}

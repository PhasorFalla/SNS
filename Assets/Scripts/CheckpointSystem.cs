using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{

    public Transform Spawnpoint;
    public AudioClip checkpointSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FanReset.deathzone.spawnpoint = Spawnpoint;
            if(checkpointSFX != null) { AudioManager.audioManager.PlaySound(checkpointSFX); }
        }
    }
}

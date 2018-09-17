using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{

    public Transform Spawnpoint;
    public ParticleSystem onBeacon;
    public ParticleSystem offBeacon;
    public ParticleSystem burst;
    public GameObject checkpointLight;
    public Material mat;
    public AudioClip checkpointSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            if(FanReset.deathzone.spawnpoint != Spawnpoint)
            {
                FanReset.deathzone.spawnpoint = Spawnpoint;
                if (checkpointSFX != null) { AudioManager.audioManager.PlaySound(checkpointSFX); } //sound clip
                burst.Play();
                onBeacon.emissionRate = 5;
                offBeacon.emissionRate = 0;
            }
            if (checkpointLight != null) //light material
            {
                checkpointLight.GetComponent<MeshRenderer>().material = mat;
            }

        }
    }
}

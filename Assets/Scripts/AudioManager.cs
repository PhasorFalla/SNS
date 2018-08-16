using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source;

    public static AudioManager audioManager;

    private void Start()
    {
        audioManager = this;
        if (audioManager != this)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
        source = Camera.main.GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip audio)
    {
        source.clip = audio;
        source.Play();
    }
	
}

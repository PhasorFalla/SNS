using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip buttonHover;
    public AudioClip buttonClick;

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

    public void ButtonClick()
    {
        source.clip = buttonClick;
        source.Play();
    }

    public void ButtonHover()
    {
        source.clip = buttonHover;
        source.Play();
    }
	
}

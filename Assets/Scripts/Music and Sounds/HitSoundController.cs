using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitSoundController : MonoBehaviour
{
    private AudioSource sound;
    public static Action OnHit;
    private float soundVolume;
    void Start()
    {
        sound = GetComponent<AudioSource>();

        soundVolume = PlayerPrefs.GetFloat("Sound Volume");
        OnHit += PlaySound;
    }
    void Update()
    {
        soundVolume = PlayerPrefs.GetFloat("Sound Volume");
        sound.volume = soundVolume;
        PlayerPrefs.SetFloat("Sound Volume", sound.volume);
    }

    public void PlaySound()
    {
        sound.Play();
    }
}

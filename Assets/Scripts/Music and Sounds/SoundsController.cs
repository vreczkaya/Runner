using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundsController : MonoBehaviour
{
    private  AudioSource sound;
    public static Action OnCoinHit;

    public Slider soundController;
    void Start()
    {
        sound = GetComponent<AudioSource>();

        soundController.value = PlayerPrefs.GetFloat("Sound Volume");
        OnCoinHit += PlaySound;
    }
    void Update()
    {
        sound.volume = soundController.value;
        PlayerPrefs.SetFloat("Sound Volume", sound.volume);
    }

    public  void PlaySound()
    {
        sound.Play();
    }
}

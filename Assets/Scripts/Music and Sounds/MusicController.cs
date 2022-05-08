using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    private AudioSource music;

    public Slider musicController;
    void Start()
    {
        music = GetComponent<AudioSource>();
        musicController.value = PlayerPrefs.GetFloat("Music Volume");
    }
    void Update()
    {
        music.volume = musicController.value;
        PlayerPrefs.SetFloat("Music Volume", music.volume);
    }

}

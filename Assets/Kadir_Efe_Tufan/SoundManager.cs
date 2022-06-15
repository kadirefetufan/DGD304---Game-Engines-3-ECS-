using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("About Back Ground Music: "), Space]
    [SerializeField] private AudioSource bGMusic;
    [SerializeField] private float musicVolume;

    [Header("Music Buttons Variants: "), Space]
    [SerializeField] private GameObject muteButton;
    [SerializeField] private GameObject unmuteButton;


    private void Awake() => AwakeInit();
    private void Update() => UpdateInit();
    private void AwakeInit()
    {
        DontDestroyOnLoad(bGMusic);
    }

    private void UpdateInit()
    {
        SoundButtonIconChanger();
    }

    private void SoundButtonIconChanger()
    {
        if (PlayerPrefs.GetInt("IsMute") == 1)
        {
            muteButton.SetActive(false);
            unmuteButton.SetActive(true);
            bGMusic.volume = musicVolume;
        }
        else
        {
            muteButton.SetActive(true);
            unmuteButton.SetActive(false);
            bGMusic.volume = 0;
        }
    }

    public void MuteButton()
    {
        if (muteButton.activeInHierarchy)
            PlayerPrefs.SetInt("IsMute", 1);

        else if (unmuteButton.activeInHierarchy)
            PlayerPrefs.SetInt("IsMute", 0);
    }

}

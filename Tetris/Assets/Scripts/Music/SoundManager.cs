using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private bool _muteBackgroundMusic = false;
    public static SoundManager instance;

    private AudioSource _ausioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }


    private void Start()
    {
        _ausioSource = GetComponent<AudioSource>();
        _ausioSource.Play();
    }

    public void ToogleBackgroundMusic()
    {
        _muteBackgroundMusic = !_muteBackgroundMusic;
        if (_muteBackgroundMusic)
        {
            _ausioSource.Stop();
        }
        else
        {
            _ausioSource.Play();
        }
    }


    public bool IsBackgroundMusicMuted()
    {
        return _muteBackgroundMusic;
    }
}

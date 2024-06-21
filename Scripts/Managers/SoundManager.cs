using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance
    {
        get { return instance; }
    }

    [SerializeField] private DataCache cacheData;
    [SerializeField] private AudioMixerGroup sfxOutput;
    [SerializeField] private AudioMixerSnapshot sfxDefault, sfxMuted, sfxLow, sfxMedium, sfxHigh, musicDefault, musicMuted;
    [SerializeField] private float timeToReachSnapshot = 0.5f;
    public AudioSource musicSource;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }
}

    
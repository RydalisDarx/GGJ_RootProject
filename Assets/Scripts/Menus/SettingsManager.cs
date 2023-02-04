using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{

    public static SettingsManager instance;
    
    [SerializeField] AudioMixer audioMixer;

    public const string MUSIC_KEY = "MusicVolume";
    public const string SFX_KEY = "SFXVolume";

    void Awake()
    {
        if(instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }

    }

    void LoadVolume()
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);

        audioMixer.SetFloat(OptionsMenu.MIXER_MUSIC, Mathf.Log10(musicVolume) * 20);
        audioMixer.SetFloat(OptionsMenu.MIXER_SFX, Mathf.Log10(sfxVolume) * 20);
    }

}

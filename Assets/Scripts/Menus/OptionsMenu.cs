using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    public static bool IsGamePaused = false;

    [SerializeField] GameObject optionsMenu;

    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    public const string MIXER_MUSIC = "MusicVolume";
    public const string MIXER_SFX = "SFXVolume";

    void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat(SettingsManager.MUSIC_KEY, 1f);
        sfxSlider.value = PlayerPrefs.GetFloat(SettingsManager.SFX_KEY, 1f);
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat(SettingsManager.MUSIC_KEY, musicSlider.value);
        PlayerPrefs.SetFloat(SettingsManager.SFX_KEY, sfxSlider.value);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsGamePaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        optionsMenu.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
    }

    public void Pause()
    {
        optionsMenu.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat(MIXER_MUSIC, Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat(MIXER_SFX, Mathf.Log10(volume) * 20);
    }

    public void LoadFamilyTree()
    {
        SceneManager.LoadScene("FamilyTree");
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene(0); //Title Menu should always be set as 1st scene index in Build Settings which is 0
    }

    public void Quit()
    {
        Application.Quit();
    }

}

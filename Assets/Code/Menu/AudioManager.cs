using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    [Header("OptionsMenu")]
    public Slider SliderSFXVolume; 
    public Slider SliderMasterVolume; 
    public Toggle ToggleMute;
    private float LastVolume;

    private void Awake()
    {
        SliderSFXVolume.onValueChanged.AddListener(SetSFXVolume);
        SliderMasterVolume.onValueChanged.AddListener(SetMasterVolume);
        ToggleMute.onValueChanged.AddListener(delegate { SetMute(); });
    }

    public void SetMute()
    {
        if(ToggleMute.isOn)
        {
            audioMixer.GetFloat("MasterVolume", out LastVolume);
            PlayerPrefs.SetFloat("SavedVolume", LastVolume);
            PlayerPrefs.Save();
            audioMixer.SetFloat("MasterVolume", -80);
        }
        else
        {
        float savedVolume = PlayerPrefs.GetFloat("SavedVolume", 0f);
        audioMixer.SetFloat("MasterVolume", savedVolume);
        }
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20); 
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }


}

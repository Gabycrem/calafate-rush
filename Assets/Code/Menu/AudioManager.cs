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
    private float lastVolume = 0;

    private float _savedVolume = 0;

    private void Awake()
    {
        SliderSFXVolume.onValueChanged.AddListener(SetSFXVolume);
        SliderMasterVolume.onValueChanged.AddListener(SetMasterVolume);
        ToggleMute.onValueChanged.AddListener(SetMute);
    }

    public void SetMute(bool isMuted)
    {
        if (isMuted)
        {
            audioMixer.GetFloat("MasterVolume", out lastVolume);
            Debug.LogError(lastVolume);
            _savedVolume = lastVolume;
            audioMixer.SetFloat("MasterVolume", -80);
        }
        else
        {
            audioMixer.SetFloat("MasterVolume", _savedVolume);
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

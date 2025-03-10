using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSound : MonoBehaviour
{
    private AudioSource sound;
    public AudioClip BtnClick;
    public AudioClip BtnSwitch;
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void ClickAudioOn()
    {
        sound.PlayOneShot(BtnClick);
    }

    public void SwitchAudioOn()
    {
        sound.PlayOneShot(BtnSwitch);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class Timer : MonoBehaviour
{
    public Text timerText;
    public int Minutes;
    public float Seconds;
    public float limitTime;
    public Color colorWarning;
    public bool timeOut;
    public string sceneToLoad;
    public static event Action OnTimeOut;

    private void Start()
    {
        timerUpdate();
    }

    private void Update()
    {
        if(timeOut == true)
        {
            return;
        }
        Seconds -= Time.deltaTime;

        if(Seconds <= 0)
        {
            if(Minutes == 0)
            {
                Action();
            }
            else
            {
                Seconds = 60;
                Minutes -= 1;
            }
        }

        timerUpdate();

        if(Seconds < limitTime && Minutes < 1)
        {
            timerText.color = colorWarning;
        }
    }

    public void timerUpdate()
    {
        if(Seconds < 9.9f)
        {
            if(Minutes < 9.9f)
            {
                timerText.text = Minutes.ToString() + ":" + Seconds.ToString("0.0");
            }
            else
                timerText.text = Minutes.ToString() + ":0" + Seconds.ToString("f0");
        }
        else
        {
            timerText.text = Minutes.ToString() + ":" + Seconds.ToString("f0");
        }
    }

    public void Action()
    {
        timeOut = true;
        timerText.text = "Game Over";
        OnTimeOut?.Invoke();
        Invoke("StartScene", 1.5f);

    }

    public void StartScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

}
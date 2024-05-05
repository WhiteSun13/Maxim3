using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using SimpleJSON;

public class YaAd : MonoBehaviour
{
    public static YaAd instance;
    public bool ShowAD = true;
    public string device;

    [DllImport("__Internal")]
    private static extern void ShowFullscreen();

    [DllImport("__Internal")]
    private static extern void ShowDevice();

    void Start()
    {
        ShowDevice();
        if (ShowAD)
        {
            var random = Random.Range(0, 101);

            if (random <= 40)
            {
                ShowFullscreen();
            }
        }
    }

    public void StopBeforeAd()
    {
        FindObjectOfType<AudioManager>().Pause();
        Time.timeScale = 0f;
    }

    public void ResumeAfterAd()
    {
        FindObjectOfType<AudioManager>().Continue();
        Time.timeScale = 1f;
    }

    public void GettingDevice(string _device)
    {
        device = _device;
    }
}

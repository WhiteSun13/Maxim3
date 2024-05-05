using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VidPlayer : MonoBehaviour
{
    
    [SerializeField] string videoFileName;
    public bool isPlaying = true;
    private VideoPlayer videoPlayer;

    void Start()
    {
        if (isPlaying) PlayVideo();
    }

    void Update()
    {
        // Проверяем, было ли нажатие на экран
        if (Input.GetMouseButtonDown(0) && !isPlaying)
        {
            PlayVideo();
            isPlaying = true;
            GetComponent<AutoLoad>().enabled = true;
        }
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (videoPlayer)
        {
            if (!hasFocus) { videoPlayer.Pause(); }
            else { videoPlayer.Play(); }
        }
    }

    void OnApplicationPause(bool isPaused)
    {
        if (videoPlayer)
        {
            if (isPaused) { videoPlayer.Pause(); }
            else { videoPlayer.Play(); }
        }
    }

    public void PlayVideo()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        if (videoPlayer)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            Debug.Log(videoPath);
            videoPlayer.url = videoPath;
            videoPlayer.Play();
        }
    }
}

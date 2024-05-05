using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject pauseUI;
    public GameObject loadingPanel;
    public GameObject GoverUI;
    public GameObject RestartPanel;

    private YaAd YaAd;
    public GameObject MobileUI;
    public GameObject GOPostProcess;
    private void Start()
    {
        YaAd = FindObjectOfType<YaAd>();
    }
    //public int levelToLoad;
    void Update()
    {
        if (YaAd.device == "mobile" || YaAd.device == "tablet") { MobileUI.SetActive(true); FindObjectOfType<PostProcessLayer>().enabled = false; GOPostProcess.SetActive(false); }
        else { MobileUI.SetActive(false); FindObjectOfType<PostProcessLayer>().enabled = true; GOPostProcess.SetActive(true); }

        if (Input.GetKeyDown(KeyCode.Return) && !Player.GameOver && !Moto.GameOver)
        {
            if (Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (Player.GameOver || Moto.GameOver)
        {
            GoverUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FindObjectOfType<AudioManager>().Stop("MainMusic");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            GoverUI.SetActive(false);
        }
    }
    public void Resume()
    {
        FindObjectOfType<AudioManager>().Play("PauseOut");
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }
    public void Pause()
    {
        FindObjectOfType<AudioManager>().Play("PauseIn");
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }
    public void ToMenu()
    {
        FindObjectOfType<AudioManager>().Stop("MainMusic");
        Time.timeScale = 1f;
        Paused = false;
        loadingPanel.SetActive(true);
    }
    public void QuitGame()
    {
        PlayerPrefs.DeleteAll();
        FindObjectOfType<AudioManager>().Stop("MainMusic");
        Time.timeScale = 1f;
        Paused = false;
        RestartPanel.SetActive(true);
    }
}

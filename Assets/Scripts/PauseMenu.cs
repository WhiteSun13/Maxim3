using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject pauseUI;
    public GameObject loadingPanel;
    public GameObject GoverUI;
    public GameObject RestartPanel;
    //public int levelToLoad;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !Player.GameOver && !Moto.GameOver)
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
    void Pause()
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

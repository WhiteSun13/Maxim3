using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MMBtn : MonoBehaviour
{
    public GameObject loadingPanel;
    public GameObject loadPanel;
    public GameObject ExitPanel;
    public AudioSource bgSource;
    public float deltaVolume = 10;
    public void PlayGame()
    {
        PlayerPrefs.DeleteAll();
        bgSource.volume -= deltaVolume;
        //FindObjectOfType<Menu>().LoadGame();
        loadingPanel.SetActive(true);
    }
    public void QuitGameQuest()
    {
        ExitPanel.SetActive(true);
    }
    public void QuitGameNo()
    {
        ExitPanel.SetActive(false);
    }
    public void QuitGame()
    {
        Debug.Log("Exit");
        bgSource.volume -= deltaVolume;
        //FindObjectOfType<Menu>().LoadGame();
        Application.Quit();
    }
    public void PlayDemo()
    {
        PlayerPrefs.DeleteAll();
        bgSource.volume -= deltaVolume;
        //FindObjectOfType<Menu>().LoadGame();
        loadPanel.SetActive(true);
    }
}

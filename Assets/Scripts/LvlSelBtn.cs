using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlSelBtn : MonoBehaviour
{
    public GameObject loadingPanel;
    public AudioSource bgSource;
    public float deltaVolume = 10;
    
    public void LVLSelected()
    {
        PlayerPrefs.DeleteAll();
        Time.timeScale = 1f;
        if (bgSource != null)
        {
            bgSource.volume -= deltaVolume;
        }
        else
        {
            FindObjectOfType<AudioManager>().Stop("MainMusic");
        }
        //FindObjectOfType<Menu>().LoadGame();
        loadingPanel.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController levelController;
    public Text livesText;
    public Text BossText;
    public Slider slider;
    public Slider Bossslider;
    public int phealth;
    public GameObject TwoPhase;
    public GameObject NextUI;

    void Start()
    {
        levelController = this;
    }

    void Update()
    {
        
    }
    public void SetLivesText(int lives)
    {
        livesText.text = lives.ToString();
        slider.value = lives;
    }
    public void SetBossLivesText(int lives)
    {
        if (lives <= phealth && TwoPhase != null)
        {
            TwoPhase.SetActive(true);
        }
        if (lives <= 0)
        {
            NextUI.SetActive(true);
            PlayerPrefs.DeleteAll();
            FindObjectOfType<AudioManager>().Stop("MainMusic");
        }
        BossText.text = lives.ToString();
        Bossslider.value = lives;
    }
}

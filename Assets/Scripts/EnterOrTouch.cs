using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterOrTouch : MonoBehaviour
{
    private YaAd YaAd;
    private Text sprite;
    private void Start()
    {
        YaAd = FindObjectOfType<YaAd>();
        sprite = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (YaAd.device == "mobile" || YaAd.device == "tablet") { sprite.text = "Коснитесь экрана"; }
        else { sprite.text = "Нажмите Enter"; }
    }
}

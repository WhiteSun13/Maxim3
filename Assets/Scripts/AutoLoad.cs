using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoLoad : MonoBehaviour
{
	public float fireRate;
	public int levelToLoad;
    public KeyCode _keyCode = KeyCode.Return;
    // Use this for initialization
    void Start()
	{
		InvokeRepeating("LOL", fireRate, fireRate);
	}

    void Update()
    {
        if (Input.GetKeyDown(_keyCode)) LOL();
    }

    void LOL()
	{
		if (FindObjectOfType<AudioManager>() != null)
        {
			FindObjectOfType<AudioManager>().Stop("MainMusic");
		}
		SceneManager.LoadScene(levelToLoad);
	}
}

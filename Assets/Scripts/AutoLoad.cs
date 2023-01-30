using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoLoad : MonoBehaviour
{
	public float fireRate;
	public int levelToLoad;
	// Use this for initialization
	void Start()
	{
		InvokeRepeating("LOL", fireRate, fireRate);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLVL : MonoBehaviour
{
	public GameObject NextUI;
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		Player player = other.GetComponent<Player>();
		if (player != null)
		{
			NextUI.SetActive(true);
			PlayerPrefs.DeleteAll();
			FindObjectOfType<AudioManager>().Stop("MainMusic");
		}
	}
}

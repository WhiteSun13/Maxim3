using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{
	public bool isLiser;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "MainCamera")
		{
			if (isLiser) GetComponent<LiserShoot>().enabled = true;
			else GetComponent<EnemyShoot>().enabled = true;
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "MainCamera")
		{
			if (isLiser) GetComponent<LiserShoot>().enabled = false;
			else GetComponent<EnemyShoot>().enabled = false;
		}
	}
}

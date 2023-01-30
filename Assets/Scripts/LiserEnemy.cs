using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiserEnemy : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "MainCamera")
		{
			GetComponent<LiserShoot>().enabled = true;
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "MainCamera")
		{
			GetComponent<LiserShoot>().enabled = false;
		}
	}
}

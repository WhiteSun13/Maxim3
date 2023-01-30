using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{

	public int damage = 1;
	public GameObject bulletEffect;
	public bool destroyByContact = true;
	public bool destroyShots = false;

	private void OnTriggerEnter2D(Collider2D other)
	{
		CharacterLife character = other.GetComponent<CharacterLife>();
		DoDamage shot = other.GetComponent<DoDamage>();
		if (character != null)
		{
			character.TakeDamage(damage);
			if (destroyByContact)
            {
				Instantiate(bulletEffect, transform.position, Quaternion.identity);
				Destroy(gameObject);
            }
				
		}
        else if (shot != null && destroyShots)
		{
			Destroy(other.gameObject);
		}
		else
		{
			if (destroyByContact)
				Instantiate(bulletEffect, transform.position, Quaternion.identity);
				Destroy(gameObject);
		}
	}
	private void LiserShoot()
	{
		FindObjectOfType<AudioManager>().Play("LiserShot");
	}
	private void LiserTimer()
	{
		FindObjectOfType<AudioManager>().Play("LiserTimer");
	}
}

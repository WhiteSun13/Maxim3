using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{

	public ItemEffect effect;

	private void OnTriggerEnter2D(Collider2D other)
	{
		Player player = other.GetComponent<Player>();
		CharacterLife charlife = other.GetComponent<CharacterLife>();
		if (player != null || other.GetComponent<Moto>() != null)
		{
			charlife.SetItemEffect(effect);
			FindObjectOfType<AudioManager>().Play("Health");
			Destroy(gameObject);
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum ItemEffect
{
	Hpsmal, Hpmed, Hpbig
}

public class CharacterLife : MonoBehaviour
{

	public int health;
	public int healthmax;
	public GameObject explosion;
	public Color damageColor;
	public int scorePoints;
	public GameObject[] dropItems;
	public bool isBoss = false;

	[HideInInspector]
	public bool isDead = false;
	public GameObject DeathEffect;
	private SpriteRenderer sprite;
	private static int chanceToDroptItem = 20;

	// Use this for initialization
	void Start()
	{

		sprite = GetComponent<SpriteRenderer>();


	}

	public void TakeDamage(int damage)
	{
		if (!isDead)
		{
			health -= damage;
			if (this.GetComponent<Player>() != null || this.GetComponent<Moto>() != null)
			{
				LevelController.levelController.SetLivesText(health);
			}
            //else
            //{
				//FindObjectOfType<AudioManager>().Play("EnemyDamage");
			//}
			if (isBoss)
            {
				LevelController.levelController.SetBossLivesText(health);
			}
			if (health <= 0)
			{
				isDead = true;
				if (DeathEffect != null)
					Instantiate(DeathEffect, transform.position, transform.rotation);
				if (this.GetComponent<Player>() != null)
				{
					health = 0;
					GetComponent<Player>().Respawn();
				}
				else if (this.GetComponent<Moto>() != null)
                {
					health = 0;
					GetComponent<Moto>().Respawn();
				}
				else
				{

					chanceToDroptItem++;
					int random = Random.Range(0, 100);
					if (random < chanceToDroptItem && dropItems.Length > 0)
					{
						Instantiate(dropItems[Random.Range(0, dropItems.Length)], transform.position, Quaternion.identity);
						//chanceToDroptItem = 0;
					}
					FindObjectOfType<AudioManager>().Play("EnemyDeath");
					Destroy(gameObject);
				}
			}
			else
			{
				StartCoroutine(TakingDamage());
			}
		}
	}

	IEnumerator TakingDamage()
	{
		sprite.color = damageColor;
		yield return new WaitForSeconds(0.1f);
		sprite.color = Color.white;
	}
	
	public void SetItemEffect(ItemEffect effect)
	{
		if (this.GetComponent<Player>() != null || this.GetComponent<Moto>() != null)
		{
			if (effect == ItemEffect.Hpsmal)
			{
				health += 5;
			}
			else if (effect == ItemEffect.Hpmed)
			{
				health += 10;
			}
			else if (effect == ItemEffect.Hpbig)
			{
				health += 20;
			}
			if (health > healthmax)
            {
				health = healthmax;
            }
			LevelController.levelController.SetLivesText(health);
		}
	}
}

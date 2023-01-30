using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
	[SerializeField]
	public GameObject bullet;
	public GameObject bulletEffect;
	public float fireRate;
	public float fireStart;
	public Transform[] shotSpawns;
	private float nextSpawn;
	public static bool Auditore = false;

	void Start()
	{
		InvokeRepeating("Fire", fireStart, fireRate);
	}

	void Fire()
	{
		if (enabled == true)
        {
			for (int i = 0; i < shotSpawns.Length; i++)
			{
				FindObjectOfType<AudioManager>().Play("EnemyShoot");
				Instantiate(bulletEffect, shotSpawns[i].position, shotSpawns[i].rotation);
				Instantiate(bullet, shotSpawns[i].position, shotSpawns[i].rotation);
			}

        }
		
	}
}
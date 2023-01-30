using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiserShoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletEffect;
    public float fireRate;
    public Transform[] shotSpawns;
    private float nextSpawn;
    private int i = 0;
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + fireRate;
            FindObjectOfType<AudioManager>().Play("EnemyShoot");
            Instantiate(bulletEffect, shotSpawns[i].position, shotSpawns[i].rotation);
            Instantiate(bullet, shotSpawns[i].position, shotSpawns[i].rotation);
            if (i < 6) i++;
            else i = 0;
        }
    }
}

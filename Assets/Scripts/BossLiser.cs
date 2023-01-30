using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLiser : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate;
    public Transform[] shotSpawns;
    private float nextSpawn;
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + fireRate;
            Instantiate(bullet, shotSpawns[Random.Range(0, shotSpawns.Length)].position, shotSpawns[Random.Range(0, shotSpawns.Length)].rotation);
        }
    }
}

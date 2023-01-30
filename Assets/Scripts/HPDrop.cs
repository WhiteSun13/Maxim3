using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPDrop : MonoBehaviour
{
    public GameObject[] bullet;
    public float fireRate;
    public Transform[] shotSpawns;
    private float nextSpawn;
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + fireRate;
            Instantiate(bullet[Random.Range(0, shotSpawns.Length)], shotSpawns[Random.Range(0, shotSpawns.Length)].position, shotSpawns[Random.Range(0, shotSpawns.Length)].rotation);
        }
    }
}

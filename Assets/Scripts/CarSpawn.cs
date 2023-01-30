using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    public GameObject[] cars;
    public float fireRate;
    public float MinfireRate;
    public Transform[] shotSpawns;
    private float nextSpawn;
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + Random.Range(MinfireRate, fireRate);
            Instantiate(cars[Random.Range(0, cars.Length)], shotSpawns[Random.Range(0, shotSpawns.Length)].position, shotSpawns[Random.Range(0, shotSpawns.Length)].rotation);
        }
    }
}

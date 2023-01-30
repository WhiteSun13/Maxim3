using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSheald : MonoBehaviour
{
    public float fireRate;
    private float nextSpawn;
    public GameObject Bsheald;
    public bool BSX = true;
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + fireRate;
            Bsheald.SetActive(BSX);
            BSX = !BSX;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnP : MonoBehaviour
{
    public GameObject Enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MainCamera") //&& Time.time > nextSpawn)
        {
            Instantiate(Enemy, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

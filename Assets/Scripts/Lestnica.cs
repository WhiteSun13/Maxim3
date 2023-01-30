using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lestnica : MonoBehaviour
{
    [SerializeField]
    float speed = 5;
    private float moveInput;
    void OnTriggerStay2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().gravityScale = 0;
        if (other.gameObject.CompareTag("Player"))
        {
            moveInput = Input.GetAxis("Vertical");
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, moveInput * speed);
        }
        else
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().gravityScale = 2;
    }
}

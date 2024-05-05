using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lestnica : MonoBehaviour
{
    [SerializeField]
    float speed = 5;
    private float moveInput;
    private YaAd YaAd;
    public VariableJoystick MoveJoystick;
    private void Start()
    {
        YaAd = FindObjectOfType<YaAd>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().gravityScale = 0;
        if (other.gameObject.CompareTag("Player"))
        {
            if (YaAd.device == "mobile" || YaAd.device == "tablet") { moveInput = MoveJoystick.Vertical; }
            else { moveInput = Input.GetAxis("Vertical"); }
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

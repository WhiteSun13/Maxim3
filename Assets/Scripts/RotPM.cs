using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotPM : MonoBehaviour
{
    Vector3 pos;
    Camera main;
    private YaAd YaAd;
    public VariableJoystick ShootJoystick;

    private void Start()
    {
        main = FindObjectOfType<Camera>();
        YaAd = FindObjectOfType<YaAd>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();

        pos = main.WorldToScreenPoint(transform.position);
    }
    void Flip()
    {
        if (YaAd.device == "mobile" || YaAd.device == "tablet")
        {
            if (ShootJoystick.Horizontal < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            if (ShootJoystick.Horizontal >= 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            if (Input.mousePosition.x < pos.x)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            if (Input.mousePosition.x > pos.x)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}

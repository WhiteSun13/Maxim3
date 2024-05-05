using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotm : MonoBehaviour
{
    public float offset;
    public VariableJoystick ShootJoystick;

    private YaAd YaAd;
    private void Start()
    {
        YaAd = FindObjectOfType<YaAd>();
    }

    void Update()
    {
        float rotZ = 0;
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (YaAd.device == "mobile" || YaAd.device == "tablet")
        {
            rotZ = Mathf.Atan2(ShootJoystick.Vertical, ShootJoystick.Horizontal) * Mathf.Rad2Deg;
        }
        else
        {
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        }
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        Vector3 LocalScale = Vector3.one;

        if(rotZ > 90 || rotZ < -90)
        {
            LocalScale.y = -1f;
        }
        else
        {
            LocalScale.y = +1f;
        }
        transform.localScale = LocalScale;
    }
}

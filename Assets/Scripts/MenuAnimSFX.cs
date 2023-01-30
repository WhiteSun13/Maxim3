using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimSFX : MonoBehaviour
{
    public AudioSource Myfx;
    public AudioClip Menu1;
    public AudioClip Menu2;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Myfx.PlayOneShot(Menu1);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Myfx.PlayOneShot(Menu2);
        }
    }
}

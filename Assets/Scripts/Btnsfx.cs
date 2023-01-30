using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btnsfx : MonoBehaviour
{
    public AudioSource Myfx;
    public AudioClip clickfx;
    public AudioClip hoverfx;
    // Start is called before the first frame update
    public void ClickSound()
    {
        Myfx.PlayOneShot(clickfx);
    }
    public void HoverSound()
    {
        Myfx.PlayOneShot(hoverfx);
    }
}

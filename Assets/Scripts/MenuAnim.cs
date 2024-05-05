using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnim : MonoBehaviour
{
    public Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            anim.Play("Menu1");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            anim.Play("Menu2");
        }
    }

    public void StartMenu()
    {
        anim.Play("Menu1");
    }
}

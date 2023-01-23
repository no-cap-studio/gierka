using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animator : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sprite;
    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        keyCheck();
    }
    void keyCheck()
    {
        if(Input.GetKey(KeyCode.A))
        {
            anim.SetBool("idle", false);
            if (!Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.S))
            {
                anim.SetInteger("walkx", 1);
                anim.SetInteger("walky", 0);
                sprite.flipX = false;
                anim.SetInteger("last", 0);

            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("idle", false);
            if (!Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.S))
            {
                anim.SetInteger("walkx", 1);
                anim.SetInteger("walky", 0);
                anim.SetInteger("last", 1);
                sprite.flipX=true;
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("idle", false);
            anim.SetInteger("walky", 1);
            anim.SetInteger("walkx", 0);
            anim.SetInteger("last", 2);

        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("idle", false);
            anim.SetInteger("walky", -1);
            anim.SetInteger("walkx", 0);
            anim.SetInteger("last", 3);
        }
        if(!Input.GetKey(KeyCode.S)&&!Input.GetKey(KeyCode.A)&&!Input.GetKey(KeyCode.D)&&!Input.GetKey(KeyCode.W))
        {
            anim.SetBool("idle",true);
            if (anim.GetInteger("last") == 2)
            {
                sprite.flipX = true;
            }
            
        }
    }
}

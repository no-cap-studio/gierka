using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAnimationCotrol : MonoBehaviour
{
    public GameObject player;
    Animator anim;
    SpriteRenderer spr;
    public RayCast ray;
    void Start()
    {
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        ray = GetComponentInChildren<RayCast>();
    }

    void Update()
    {
        animacje();
    }

    void animacje()
    {
        if (ray.cel != null)
        {
            if (Mathf.Abs(transform.position.x - ray.cel.x) > Mathf.Abs(transform.position.y - ray.cel.y))
            {
                if (transform.position.x > ray.cel.x)
                {
                    anim.SetInteger("walkx", 1);
                    anim.SetInteger("walky", 0);
                    spr.flipX = false;
                }
                else
                {
                    anim.SetInteger("walkx", 1);
                    anim.SetInteger("walky", 0);
                    spr.flipX = true;
                }
            }
            else
            {
                if (transform.position.y > ray.cel.y)
                {
                    anim.SetInteger("walky", 1);
                    anim.SetInteger("walkx", 0);
                    
                }
                else
                {
                    anim.SetInteger("walky", -1);
                    anim.SetInteger("walkx", 0);
                    
                }
            }
        }

    }

}




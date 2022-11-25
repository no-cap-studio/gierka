using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class aniamtionController : MonoBehaviour
{
    public GameObject player;
    public playerMovement index;
    public Animator anim;
    private IEnumerator coroutine;
   
    void Start()
    {
        
        index = player.GetComponent<playerMovement>();
        anim = player.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        animationControl();
    }

    void animationControl()
    {

      
        if (Input.GetKey(KeyCode.D))
        {
            if (!Input.GetKey(KeyCode.A))
            {
                anim.SetInteger("wolky", 0);
                anim.SetInteger("walkx", -1);
                player.GetComponent<SpriteRenderer>().flipX = true ;
            }
        }
        
        if (Input.GetKey(KeyCode.A) )
        {
           if(!Input.GetKey(KeyCode.D))
           {
                anim.SetInteger("wolky", 0);
                anim.SetInteger("walkx", -1);
                player.GetComponent<SpriteRenderer>().flipX = false;
            }
            
            
        }

        if (Input.GetKey(KeyCode.W))
        {
            if(!Input.GetKey(KeyCode.S))
            {
                anim.SetInteger("wolky", 1);
                anim.SetInteger("walkx", 0);

            }
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            if(!Input.GetKey(KeyCode.W))
            {
                anim.SetInteger("walkx", 0);
                anim.SetInteger("wolky", -1);
            }
           
        }




        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetInteger("wolky", 0);

            if(Input.GetKey(KeyCode.A))
            {
                anim.SetInteger("walkx", -1);
            }
            else if(Input.GetKey(KeyCode.D))
            {
                anim.SetInteger("walkx", 1);
            } 
            else if(Input.GetKey(KeyCode.S))
            {
                anim.SetInteger("wolky", -1);
            }
          
           
        }


        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetInteger("wolky", 0);
            if (Input.GetKey(KeyCode.A))
            {
                anim.SetInteger("walkx", -1);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                anim.SetInteger("walkx", 1);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                anim.SetInteger("wolky", 1);
            }
        }
       
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("walkx", 0);
            if (Input.GetKeyDown(KeyCode.A))
            {
                anim.SetInteger("walkx", -1);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                anim.SetInteger("walkx", 1);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                anim.SetInteger("wolky", -1);
            }


        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetInteger("walkx", 0);
            if (Input.GetKeyDown(KeyCode.W))
            {
                anim.SetInteger("wolky", 1);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                anim.SetInteger("walkx", 1);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                anim.SetInteger("wolky", -1);
            }

        }
        

        

    }

   
}

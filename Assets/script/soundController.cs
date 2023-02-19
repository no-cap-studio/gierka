using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class soundController : MonoBehaviour
{
    public Animator anim;
    public AudioSource muzyczka;
    public AudioSource jasper;
    public AudioClip grassWalk;
    private bool isPlaying = false;
    void Start()
    {
        muzyczka.Play();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) )
        {
            if (isPlaying == false)
            {
                StartCoroutine(kutas());
            }


        }
        if(!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            StopAllCoroutines();
            isPlaying = false;
        }
    }

    IEnumerator kutas()
    {
        isPlaying = true;
        yield return new WaitForSeconds(0.4f);
        jasper.PlayOneShot(grassWalk); 
        StartCoroutine(kutas());
    }
}

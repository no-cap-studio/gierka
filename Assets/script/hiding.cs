using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class hiding : MonoBehaviour
{
    public GameObject player;
    playerMovement move;
    public GameObject hideIcon;
    public Sprite unHidden;
    public Sprite hidden;
    SpriteRenderer sprite;
    public GameObject leftjasper;
    public GameObject rightjasper;
    public GameObject upjasper;
    public GameObject downjasper;
    GameObject selected;
    void Start()
    {
        move = player.GetComponent<playerMovement>();
        sprite = GetComponent<SpriteRenderer>();

    }

    public void hidinges()
    {
        sprite.sprite = hidden;
        player.GetComponent<SpriteRenderer>().enabled = false;
        move.isHiding = true;
        if (player.CompareTag("Tutorial"))
        {
            player.tag = "TutorialHiding";
        }
        else { 
            player.tag = "Untagged"; 
        }
        hideIcon.gameObject.SetActive(false);
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic; 


    }
    public void unhide()
    {
        if (move.isHiding == true && Input.GetKeyDown(KeyCode.F))
        {
            if (selected != null)
            {
                player.transform.position = selected.transform.position;
            }

            player.GetComponent<SpriteRenderer>().enabled = true;
            if (player.CompareTag("TutorialHiding"))
            {
                player.tag = "Tutorial";
            }
            else
            {
                player.tag = "Player";
            }
            sprite.sprite = unHidden;
            move.isHiding = false;
            hideIcon.gameObject.SetActive(true);
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            if (downjasper != null)
            {
                downjasper.SetActive(false);
            }
            if (upjasper != null)
            {
                upjasper.SetActive(false);
            }
            if (leftjasper != null)
            {
                leftjasper.SetActive(false);
            }
            if (rightjasper != null)
            {
                rightjasper.SetActive(false);
            }
            selected = null;
        }
        
    }

    public void choosingPosition()
    {
        if (leftjasper != null && Input.GetKey(KeyCode.A)) {

            leftjasper.SetActive(true);
            if (rightjasper != null)
            {
                rightjasper.SetActive(false);
            }
            if (upjasper != null)
            {
                upjasper.SetActive(false);
            }
            if (downjasper != null)
            {
                downjasper.SetActive(false);
            }          
            selected = leftjasper;


        }
        else if (rightjasper != null && Input.GetKey(KeyCode.D)) {

            if (leftjasper != null)
            {
                leftjasper.SetActive(false);
            }
            
            rightjasper.SetActive(true);

            if (upjasper != null)
            {
                upjasper.SetActive(false);
            }

            if (downjasper != null)
            {
                downjasper.SetActive(false);
            }

            selected = rightjasper;
        }
        else if (upjasper != null && Input.GetKey(KeyCode.W)) {

            if (leftjasper != null)
            {
                leftjasper.SetActive(false);
            }
            if (rightjasper != null)
            {
                rightjasper.SetActive(false);
            }
            upjasper.SetActive(true);
            if (downjasper != null)
            {
                downjasper.SetActive(false);
            }
            selected = upjasper;
        }
        else if (downjasper != null && Input.GetKey(KeyCode.S)) {
            if (leftjasper != null)
            {
                leftjasper.SetActive(false);
            }
            if (rightjasper != null)
            {
                rightjasper.SetActive(false);
            }
            if (upjasper != null)
            {
                upjasper.SetActive(false);
            }
            downjasper.SetActive(true);
            selected = downjasper;
        }     
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("Tutorial"))
        {
            move.hideMet = this.gameObject.GetComponent<hiding>();
            if (move.isHiding == false)
            {
                hideIcon.gameObject.SetActive(true);
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Tutorial")){
            move.hideMet = null;
            hideIcon.gameObject.SetActive(false);
        }
    }
}

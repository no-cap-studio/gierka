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
        player.tag  = "Untagged";
        hideIcon.gameObject.SetActive(false);
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic; 


    }
    public void unhide()
    {
        if (move.isHiding == true && Input.GetKeyDown(KeyCode.F))
        {
            player.GetComponent<SpriteRenderer>().enabled = true;
            player.tag = "Player";
            sprite.sprite = unHidden;
            move.isHiding = false;
            hideIcon.gameObject.SetActive(true);
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        move.hideMet = this.gameObject.GetComponent<hiding>();
        if (move.isHiding == false)
        {
            hideIcon.gameObject.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        move.hideMet = null;
        hideIcon.gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class przeszukiwanieKoszy : MonoBehaviour
{
    public GameObject player;
    playerMovement move;
    Animator anim;
    public GameObject reward;
    public GameObject spawnPoint;
    
    void Start()
    {
        move = player.GetComponent<playerMovement>();
        anim = GetComponent<Animator>();
        Debug.Log(anim.GetCurrentAnimatorStateInfo(0).length);
    }

    void Update()
    {
    }
    public void startLooking() {
        Debug.Log("nie wiem kurwa");
        player.GetComponent<SpriteRenderer>().enabled = false;
        player.tag = "Untagged";
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        anim.Play("kosz",0,60);
        StartCoroutine(finish());

    }

    public void stopLooking()
    {
        if (reward != null)
        {
            reward.transform.position = spawnPoint.transform.position;
        }
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.tag = "Player";
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    private IEnumerator finish()
    {
        yield return new WaitForSeconds(2.8f);
        stopLooking();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        move.trashCan = this;
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        move.trashCan = null;
    }
}

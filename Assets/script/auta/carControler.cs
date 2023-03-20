using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carControler : MonoBehaviour
{
    public GameObject sprite;
    private obstacleControler obstacleControler;
    public GameObject obstacle;
    public GameObject destination;
    public GameObject resp;
    private spawnControler spawn;
    private bool canMove;
    Ray2D ray;
    public float rayLength;
    public Vector2 rayDirection;
    public float velocityX;
    public float velocityY;
    void Start()
    {
        canMove = true;
        ray = new Ray2D(this.gameObject.transform.position, new(1, 0));
        spawn = resp.GetComponent<spawnControler>();
        obstacleControler = obstacle.GetComponent<obstacleControler>();
    }
    void Update()
    {
        move();
        checkForCollision();
    }
    private void move()
    {
        if (canMove)
        {
            this.gameObject.transform.Translate(velocityX * Time.deltaTime, velocityY * Time.deltaTime, 0);
            //this.gameObject.GetComponent<Animator>().enabled = true;
        }
        //else
            // this.gameObject.GetComponent<Animator>().enabled = false;
    }
    private IEnumerator waitForGreen()
    {
        yield return new WaitUntil(() => obstacleControler.isActive == true);
        canMove = true;
    }
    private void checkForCollision()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, rayDirection, rayLength);
        if (hit)
        {

            if (hit.collider.gameObject.tag == this.gameObject.tag)
                canMove = false;

            if (hit.collider.gameObject.CompareTag(obstacle.tag))
            {
                Debug.Log("obstacel");

                if (!obstacleControler.isActive)
                {
                    canMove = false;
                    StartCoroutine(waitForGreen());

                }
            }
            if (hit.collider.gameObject.name == destination.name)
            {
                Debug.Log("ded");
                Destroy(this.gameObject);
            }
        }
        else canMove = true;
    }
}

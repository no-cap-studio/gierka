using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private GameManager gameManager;
    void Start()
    {
        canMove = true;
        ray = new Ray2D(this.gameObject.transform.position, new(1, 0));
        spawn = resp.GetComponent<spawnControler>();
        obstacleControler = obstacle.GetComponent<obstacleControler>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        // this.gameObject.GetComponent<Animator>().enabled = false;
    }
    private IEnumerator waitForGreen()
    {
        yield return new WaitUntil(() => obstacleControler.isActive == true);
        canMove = true;
    }
    private IEnumerator ifStoppedForTooLong()
    {
        yield return new WaitForSeconds(obstacleControler.waitFor + 2);
        if (!canMove)
            Destroy(this.gameObject);
    }
    private void checkForCollision()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, rayLength);
        Debug.DrawRay(transform.position, rayDirection * rayLength, Color.red);
        if (hit)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                gameManager.EndGame();
            }

            if (hit.collider.gameObject.CompareTag(this.gameObject.tag))
            {
                canMove = false;
                StartCoroutine(ifStoppedForTooLong());
            }

            if (hit.collider.gameObject.CompareTag(obstacle.tag))
            {
                if (!obstacleControler.isActive)
                {
                    canMove = false;
                    StartCoroutine(waitForGreen());
                    StartCoroutine(ifStoppedForTooLong());
                }
            }
            if (hit.collider.gameObject.name == destination.name)
            {
                Destroy(this.gameObject);
            }
        }
        else canMove = true;
    }
}

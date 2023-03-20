using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destinationController : MonoBehaviour
{
    public GameObject killOnReceive;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(killOnReceive.tag))
        {
            Destroy(collision.gameObject);
        }
    }
}

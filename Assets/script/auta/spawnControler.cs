using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnControler : MonoBehaviour
{
    public GameObject sprite;
    /*public GameObject obstacle;
    public GameObject destination;*/
    public bool isActive;
    public float frequency;
    
    void Start()
    {
        this.gameObject.SetActive(true);
        StartCoroutine(spawnCars());
    }
    private IEnumerator spawnCars()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(2.0f, frequency));
        if (isActive)
        {
            GameObject clone=Instantiate(sprite, this.gameObject.transform.position, Quaternion.identity);
            /*clone.GetComponent<carControler>().sprite = sprite;
            clone.GetComponent<carControler>().obstacle = obstacle;
            clone.GetComponent<carControler>().destination = destination;*/
            clone.SetActive(true);
        }
        StartCoroutine(spawnCars());
    }
}

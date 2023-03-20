using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleControler : MonoBehaviour
{
    public bool isActive;
    private void Start()
    {
        StartCoroutine(change());
    }
    private IEnumerator change()
    {
        yield return new WaitForSeconds(6);
        if(isActive) isActive= false;
        else isActive=true;
        StartCoroutine(change());
    }
}

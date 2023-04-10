using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleControler : MonoBehaviour
{
    public bool isActive;
    public float waitFor;
    private void Start()
    {
        if (waitFor == 0)
            waitFor = 6;
        StartCoroutine(change());
    }
    private IEnumerator change()
    {
        yield return new WaitForSeconds(waitFor);
        if(isActive) isActive= false;
        else isActive=true;
        StartCoroutine(change());
    }
}

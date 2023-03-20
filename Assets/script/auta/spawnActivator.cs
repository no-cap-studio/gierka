using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnActivator : MonoBehaviour
{
    // Start is called before the first frame update
    public spawnControler spawn;
    private void OnTriggerStay2D(Collider2D collision)
    {
        spawn.isActive = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        spawn.isActive = true;
    }
}
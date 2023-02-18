using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questTypuPodnies : questCheck
{
    public override void activating()
    {
    }
    public override void checking()
    {
        
    }
    public override void finish()
    {
        Debug.Log(quest.checks.Count);
        Debug.Log(quest.checks.IndexOf(this.gameObject.GetComponent<questCheck>()));
        if (quest.checks.Count-1 > quest.checks.IndexOf(this.gameObject.GetComponent<questCheck>()))
        {
            quest.checks[quest.checks.IndexOf(this.gameObject.GetComponent<questCheck>())+1].IsActive = true;
        }
                else
        {
            quest.done = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsActive == true)
        {
            manager.cecked(this.gameObject.GetComponent<questCheck>());
        }
        
    }
}

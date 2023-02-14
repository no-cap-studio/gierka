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
        if (quest.checks.Count - 1 < quest.checks.IndexOf(this.gameObject.GetComponent<questCheck>()))
        {
            quest.checks[quest.checks.IndexOf(this.gameObject.GetComponent<questCheck>())].IsActive = true;
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

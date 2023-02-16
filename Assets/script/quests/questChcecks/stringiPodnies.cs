using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

public class stringiPodnies : questCheck
{
    public GameObject hideable;
    public przeszukiwanieKoszy[] kosze;

    int koszeIndex;

    public void Start()
    {
        kosze = hideable.GetComponentsInChildren<przeszukiwanieKoszy>();
    }
    public override void activating()
    {
        koszeIndex = Random.Range(0, kosze.Length - 1);
        kosze[koszeIndex].reward = this.gameObject;
        Debug.Log(koszeIndex);
    }

    public override void checking()
    {
        
    }

    public override void finish()
    {
        Debug.Log(quest.checks.Count);
        Debug.Log(quest.checks.IndexOf(this.gameObject.GetComponent<questCheck>()));
        if (quest.checks.Count - 1 > quest.checks.IndexOf(this.gameObject.GetComponent<questCheck>()))
        {
            quest.checks[quest.checks.IndexOf(this.gameObject.GetComponent<questCheck>()) + 1].IsActive = true;
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

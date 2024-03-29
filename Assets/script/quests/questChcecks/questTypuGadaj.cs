using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questTypuGadaj : questCheck
{
    public GameObject dialogManager;
    [HideInInspector] public DialogueTrigger triger;
    public Dialogue dialog;


    public override void activating()
    {
        triger = gameObject.GetComponent<DialogueTrigger>();
        triger.isThereQuest = true;
        triger.dialogues.Add(dialog);
        triger.check.Add(this);
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
        else {
            quest.done = true;
        }
    }
}

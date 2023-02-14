using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questTypuGadaj : questCheck
{
    public GameObject dialogManager;
    public DialogueTrigger triger;
    public Dialogue dialog;


    public override void activating()
    {
        Debug.Log("aktywuje");
        triger = gameObject.GetComponent<DialogueTrigger>();
        triger.isThereQuest = true;
        triger.dialogues.Add(dialog);
        triger.check = this.gameObject;
        

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
}

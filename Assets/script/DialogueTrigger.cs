using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string makeActive;
    public string ifActive;
    public Dialogue[] dialogue;
    public dialogManager dial;

    public void Start()
    {
        

    }
    public void triggerDialogue()
    {
        if (!string.IsNullOrEmpty(ifActive))
        {
            if (dial.dialoguePerm.ContainsKey(ifActive))
            {
                if (dial.dialoguePerm[ifActive].ToString() != "0")
                {
                    dial.startDialogue(dialogue[1]);
                }
                else
                {
                    dial.startDialogue(dialogue[0]);
                }
            }
            else {
                dial.startDialogue(dialogue[0]);
            }
            

        }
        else
        {
            dial.startDialogue(dialogue[0]);
        }
        if(!string.IsNullOrEmpty(makeActive))
        {
            dial.dialoguePerm.Add(makeActive, "1");
        }

    }
}

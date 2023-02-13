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
    public GameObject dialogIcon;
    public GameObject dialogMan;
    public Quest quest;
    public QuestManager qm;

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

        if (quest != null)
        {
            qm.questTriger(quest);
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialogIcon.SetActive(true);
            collision.gameObject.GetComponent<playerMovement>().dialogTriger = this.gameObject;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialogIcon.SetActive(false);
            collision.gameObject.GetComponent<playerMovement>().dialogTriger = null;
            dialogMan.GetComponent<dialogManager>().endDialogue();
        }

    }
}

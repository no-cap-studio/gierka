using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public List<Dialogue> dialogues;
    public dialogManager dial;
    public GameObject dialogIcon;
    public GameObject questIcon;
    public GameObject dialogMan;
    public Quest quest;
    public QuestManager qm;
    public bool isThereQuest=false;

    public void Start()
    {
        

    }
    public void triggerDialogue()
    {
        if (isThereQuest == false)
        {
            dial.startDialogue(dialogues[0]);
        }
        else {
            dial.startDialogue(dialogues[1]);
            dial.quest = quest;
            dial.dialogueTrigger = this.gameObject.GetComponent<DialogueTrigger>() ;
        }
          
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isThereQuest == false)
            {
                dialogIcon.SetActive(true);
            }
            else {
                questIcon.SetActive(true);
            }
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

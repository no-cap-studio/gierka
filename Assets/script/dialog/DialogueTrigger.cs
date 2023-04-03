using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public List<Dialogue> dialogues;
    public dialogManager dial;
    public GameObject dialogIcon;
    [HideInInspector] public GameObject questIcon;
    [HideInInspector] public Quest quest;
    public QuestManager qm;
    public List<questCheck> check;
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
            if (quest != null)
            {
                dial.startDialogue(dialogues[1]);
                dial.quest = quest;
                dial.dialogueTrigger = this.gameObject.GetComponent<DialogueTrigger>();
            }
            else if (check != null){
                dial.dialogueTrigger = this.gameObject.GetComponent<DialogueTrigger>();
                dial.check = check[check.Count - 1];
                dial.startDialogue(dialogues[dialogues.Count-1]);
                
            }
            
        }
          
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isThereQuest == false && quest ==null)
            {
                dialogIcon.SetActive(true);
            }
            collision.gameObject.GetComponent<playerMovement>().dialogTriger = this.gameObject;
            
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            dialogIcon.SetActive(false);
            collision.gameObject.GetComponent<playerMovement>().dialogTriger = null;
            dial.GetComponent<dialogManager>().endDialogue();
        }

    }
}

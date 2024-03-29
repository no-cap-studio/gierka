using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTriger : MonoBehaviour
{
    public GameObject questIcon;
    public Dialogue dialog;
    [HideInInspector]public DialogueTrigger trigerek;
    public Quest quest;
    public QuestManager manager;
    void Start()
    {
        trigerek = gameObject.GetComponent<DialogueTrigger>();
        trigerek.dialogues.Add(dialog);
        trigerek.isThereQuest = true;
        trigerek.questIcon = questIcon;
        trigerek.quest = quest;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

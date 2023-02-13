using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTriger : MonoBehaviour
{
    public GameObject questIcon;
    public Dialogue dialog;
    public DialogueTrigger trigerek;
    void Start()
    {
        trigerek = gameObject.GetComponent<DialogueTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

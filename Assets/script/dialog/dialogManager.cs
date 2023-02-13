using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class dialogManager : MonoBehaviour
{
    private Queue<string> sentences;
    public GameObject textSpace;
    public GameObject nameSpace;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI DialogueText;
    public GameObject player;
    public Hashtable dialoguePerm = new Hashtable();
    public GameObject dialogueBackGround;
    void Start()
    {
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void startDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;
        sentences.Clear();
        textSpace.SetActive(true);
        nameSpace.SetActive(true);
        dialogueBackGround.SetActive(true);
        player.GetComponent<playerMovement>().isTalking = true;

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            endDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(typeSentence(sentence));
    }

    IEnumerator typeSentence(string sentence)
    {
        DialogueText.text = "";
        foreach (char c in sentence.ToCharArray())
        {
            DialogueText.text += c;
            yield return new WaitForSeconds(0.1f); ;
        }
    }

    public void endDialogue()
    {
        textSpace.SetActive(false);
        nameSpace.SetActive(false);
        dialogueBackGround.SetActive(false);
        player.GetComponent<playerMovement>().isTalking = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class tutorialControler : MonoBehaviour
{
    public Button button;
    public PlayableDirector cutscenka;
    public dialogManager dialogManager;
    public GameObject grzib;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player.tag = "Tutorial";
        if (!cutscenka.gameObject.activeSelf)
        {
            this.gameObject.SetActive(true);
        }
       if(this.gameObject.activeSelf)
        {
            //dialogManager.DisplayNextSentence();
            //button.Select();
            //button.onClick.Invoke();
            dialogManager.startDialogue(grzib.GetComponent<DialogueTrigger>().dialogues[0]);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            endTutorial();
        }
    }

    private void endTutorial()
    {
        player.tag = "Player";
        this.gameObject.SetActive(false);
    }
}

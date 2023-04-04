using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class cutscenkaSkip : MonoBehaviour
{
    //public PlayableDirector cutscenka;
    private double skipTime = 1524.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.GetComponent<PlayableDirector>().time = skipTime;
        }
    }
}

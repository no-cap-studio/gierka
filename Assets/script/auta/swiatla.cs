using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swiatla : MonoBehaviour
{
    public Sprite czerwoneSprite;
    public Sprite zieloneSprite;
    public float ileMaMigac;
    public AnimationClip czerwone;
    public AnimationClip zielone;
    float czas;
    // Start is called before the first frame update
    void Start()
    {
        // obstacle=GetComponentInParent<obstacleControler>();
        if(GetComponentInParent<obstacleControler>().waitFor==0)
        {
            czas = 6.0f;
        }
        else
        {
            czas = GetComponentInParent<obstacleControler>().waitFor;
        }
        if (ileMaMigac == 0)
        {
            ileMaMigac = 3.0f;
        }
        czas -= ileMaMigac;
        if(GetComponentInParent<obstacleControler>().isActive)
        {
            this.GetComponent<SpriteRenderer>().sprite = czerwoneSprite;
            Debug.Log(this.GetComponent<SpriteRenderer>().sprite);
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = zieloneSprite;
            Debug.Log(this.GetComponent<SpriteRenderer>().sprite);
        }
        StartCoroutine(change());
    }

   
        private IEnumerator change()
        {
            if (this.GetComponent<SpriteRenderer>().sprite == czerwoneSprite)
            {
                //Debug.Log("czerwone triger");
                yield return new WaitForSeconds(czas);
                this.GetComponent<Animator>().enabled = true;
                this.GetComponent<Animator>().Play(czerwone.name);
                yield return new WaitForSeconds(ileMaMigac);
                this.GetComponent<Animator>().enabled = false;
                this.GetComponent<SpriteRenderer>().sprite = zieloneSprite;
                Debug.Log(this.GetComponent<SpriteRenderer>().sprite);
            }
            else
            {
                //Debug.Log("zielone triger");
                yield return new WaitForSeconds(czas);
                this.GetComponent<Animator>().enabled = true;
                this.GetComponent<Animator>().Play(zielone.name);
                yield return new WaitForSeconds(ileMaMigac);
                this.GetComponent<Animator>().enabled = false;
                this.GetComponent<SpriteRenderer>().sprite = czerwoneSprite;
            }
            StartCoroutine(change());
        }
}

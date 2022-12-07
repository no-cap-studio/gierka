using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaSpawn : MonoBehaviour
{
    
    public GameObject banan;
    // Start is called before the first frame update
    void Start()
    {
        Spawnuj();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawnuj()
    {
        
        for(int i = 0;i < 5;i++)
        {
            var position = new Vector3(Random.Range(-11.5f, 3.2f), Random.Range(-3.5f, 3.5f), 0);
            Instantiate(banan,position,Quaternion.identity );
        }    
    }    
}

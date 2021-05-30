using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beevolve : MonoBehaviour
{
    /* 
     * YES I KNOW THEY'RE TECHNICALLY WASP LARVAE BUT
     * STILL.
     * IT'S FINE.
     * shhhhhhhh
     *      -Nizi (xiaonile)
     */
    public float beevolutionTime;
    public GameObject waspSpawn;


    // Update is called once per frame
    void Update()
    {
        if(beevolutionTime <= 0)
        {
            //Beevolve
            Instantiate(waspSpawn, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            beevolutionTime -= Time.deltaTime;
        }
    }
}

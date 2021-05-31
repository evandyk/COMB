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
    Animator m_Animator;

    void Start()
    {
        m_Animator = gameObject.GetComponentInChildren<Animator>();
    }



        // Update is called once per frame
        void Update()
    {
        if (beevolutionTime <= 0 && this.GetComponent<Target>().IsAlive())
        {
            //Beevolve
            Instantiate(waspSpawn, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (beevolutionTime <= 5)
        {
            Collider eggBonker = GetComponent<Collider>();
            eggBonker.enabled = false;

            m_Animator.SetTrigger("MetaMorphosis");
            (GetComponent("WaspAggro") as MonoBehaviour).enabled = false;
            GetComponent<WaspAggro>().agent.SetDestination(transform.position);

            beevolutionTime -= Time.deltaTime;
        }
        else
        {
            beevolutionTime -= Time.deltaTime;
        }
    }
}

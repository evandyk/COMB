using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaspAggro : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform beeKeeper;
    public LayerMask groundMask, bKeeperMask;

    //Patrol
    public Vector3 patrolPt;
    bool patrolPtSet;
    public float patrolPtRange;

    //Attacking
    public float AtkCoolDown;
    bool atkOnCoolDown;

    //States
    public float sightRange, atkRange;
    public bool bKeepInSightRange, bKeepInAtkRange;


    // Update is called once per frame
    void Update()
    {
        bKeepInSightRange = Physics.CheckSphere(transform.position, sightRange, bKeeperMask);
        bKeepInAtkRange = Physics.CheckSphere(transform.position, atkRange, bKeeperMask);

        if (bKeepInSightRange && bKeepInAtkRange) Attack();
        else if (bKeepInSightRange) Chase();
        else Patrol();
    }

    private void Aggro()
    {
        beeKeeper = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Patrol()
    {
        //Find and go to the destination to patrol point:
        if (patrolPtSet)
            agent.SetDestination(patrolPt);
        else
            GetPatrolPt();

        Vector3 distanceToPatrolPt = transform.position - patrolPt;
        //Destination Reached
        if (distanceToPatrolPt.magnitude < 1f)
            patrolPtSet = false;
    }
    private void Chase()
    {
        agent.SetDestination(beeKeeper.position);
    }
    private void Attack()
    {
        //Stop running and now attack
        agent.SetDestination(transform.position);
        transform.LookAt(beeKeeper);
        if (!atkOnCoolDown)
        {
            ///INSERT ATTACK CODE HERE

            atkOnCoolDown = true;
            Invoke(nameof(ResetAtk), AtkCoolDown);
        }
    }
    private void GetPatrolPt()
    {
        //Generate a random pt to walk to within a boundary
        float randX = Random.Range(-patrolPtRange, patrolPtRange);
        float randZ = Random.Range(-patrolPtRange, patrolPtRange);

        patrolPt = new Vector3(transform.position.x + randX, transform.position.y, transform.position.z + randZ);

        //Check destination is in bounds:
        if (Physics.Raycast(patrolPt, -transform.up, 2f, groundMask))
            patrolPtSet = true;
    }
    private void ResetAtk()
    {
        atkOnCoolDown = false;
    }
}

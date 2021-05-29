using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaspAggro : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform beeKeeper;
    public LayerMask groundMask, bKeeperMask;

    public Material aggroMat;
    public Material passiveMat;

    //Patrol
    public Vector3 patrolPt;
    bool patrolPtSet;
    public float patrolPtRange;

    //Attacking
    public float AtkCoolDown;
    bool atkOnCoolDown;
    public GameObject projectile;

    //States
    public float sightRange, atkRange;
    public bool bKeepInSightRange, bKeepInAtkRange;

    private void Start()
    {
        beeKeeper = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        bKeepInSightRange = Physics.CheckSphere(transform.position, sightRange, bKeeperMask);
        bKeepInAtkRange = Physics.CheckSphere(transform.position, atkRange, bKeeperMask);

        if (bKeepInSightRange && bKeepInAtkRange)
            Attack();
        else if (bKeepInSightRange)
            Chase();
        else Patrol();
    }

    private void Patrol()
    {
        GetComponent<MeshRenderer>().material = passiveMat;

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
        GetComponent<MeshRenderer>().material = aggroMat;
        agent.SetDestination(beeKeeper.position);
    }

    private void Attack()
    {
        float spawnDistance = 1.0f;
        float force = 3000.0f;
        //Stop running and now attack
        agent.SetDestination(transform.position);

        if (!atkOnCoolDown)
        {
            //INSERT ATTACK CODE HERE
            transform.LookAt(beeKeeper);

            Rigidbody rb = Instantiate(projectile, transform.position + spawnDistance * transform.forward, transform.rotation).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * force);
            rb.AddForce(transform.up * 3f, ForceMode.Impulse);

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyManager enemyManager;
    private float enemyHealth = 10f;

    public GameObject gunHitEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth <= 0)
        {
            enemyManager.RemoveEnemy(this);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        Instantiate(gunHitEffect, transform.position, Quaternion.identity);
        enemyHealth -= damage;
    }
}

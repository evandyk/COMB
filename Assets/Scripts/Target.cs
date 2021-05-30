using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject gunHitEffect;
    public float enemyHealth = 10f;
    private bool isAlive = true;
    
    public void TakeDamage(float damage)
    {
        Instantiate(gunHitEffect, transform.position, Quaternion.identity);

        enemyHealth -= damage;
        if (enemyHealth <= 0f)
            isAlive = false;
    }

    public bool IsAlive()
    {
        return isAlive;
    }
}

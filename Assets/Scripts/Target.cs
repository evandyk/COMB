using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Target : MonoBehaviour
{
    public GameObject gunHitEffect;
    public float enemyHealth = 10f;
    
    private bool isAlive = true;
    
    public void TakeDamage(float damage, RaycastHit hit)
    {
        GameObject hitEffect = Instantiate(gunHitEffect, hit.point, Quaternion.LookRotation(hit.normal));

        enemyHealth -= damage;
        if (enemyHealth <= 0f)
            isAlive = false;

        Destroy(hitEffect, 2f);
    }

    public bool IsAlive()
    {
        return isAlive;
    }
}

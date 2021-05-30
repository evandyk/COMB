using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Target : MonoBehaviour
{
    public GameObject gunHitEffect;
    public AudioClip hitSound;
    public float enemyHealth = 10f;
    
    private bool isAlive = true;
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        if (source == null)
            source = gameObject.AddComponent<AudioSource>();
    }
    
    public void TakeDamage(float damage, RaycastHit hit)
    {
        GameObject hitEffect = Instantiate(gunHitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        source.PlayOneShot(hitSound, 0.7f);

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

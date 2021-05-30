using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : MonoBehaviour
{
    public float range = 20f;
    public float verticalRange = 20f;

    public float fireRate = .3f;
    public float gunDamage = 2f;

    public int maxAmmo;
    private int ammo;

    private float nextTimeToFire;
    private BoxCollider gunTrigger;
    public EnemyManager enemyManager;

    public LayerMask raycastLayerMask;
    public LayerMask enemyLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(1, verticalRange, range);
        gunTrigger.center = new Vector3(0, 0, range * .5f);
        ammo = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire && ammo > 0)
            Fire();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Add enemy to shoot
        Enemy wasp = other.transform.GetComponent<Enemy>();
        
        if(wasp)
        {
            enemyManager.AddEnemy(wasp);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Remove enemy
        Enemy wasp = other.transform.GetComponent<Enemy>();

        if (wasp)
        {
            enemyManager.RemoveEnemy(wasp);
        }
    }

    void Fire()
    {
        // Damage enemies
        foreach(var wasp in enemyManager.enemiesInTrigger)
        {
            // Dummy sound
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().Play();

            // Get direction to enemy
            var direction = wasp.transform.position - transform.position;

            RaycastHit hit;
            if(Physics.Raycast(transform.position, direction, out hit, range * 1.5f, raycastLayerMask))
            {
                if(hit.transform == wasp.transform)
                {
                    // Damage
                    wasp.TakeDamage(gunDamage);

                    // Range check?
                    //float dist = Vector3.Distance(wasp.transform.position, transform.position);

                    //if(dist > range * .5f)
                    //{
                    //    // Damage
                    //    wasp.TakeDamage(smallDamage);
                    //}
                    //else
                    //{
                    //    wasp.TakeDamage(bigDamage);
                    //}
                }
            }
        }

        // Reset timer
        nextTimeToFire = Time.time + fireRate;

        ammo--;
    }

    public void GiveAmmo(int amount, GameObject pickup)
    {
        if (ammo < maxAmmo)
        {
            ammo += amount;
            Destroy(pickup);
        }
        else
            ammo = maxAmmo;
    }
}

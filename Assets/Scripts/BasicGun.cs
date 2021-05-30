using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : MonoBehaviour
{
    public EnemyManager enemyManager;

    public float range = 20f;
    public float verticalRange = 20f;
    public float fireRate = .3f;
    public float gunDamage = 2f;
    public int maxAmmo = 100;

    private int ammo = 20;
    private float nextTimeToFire;

    //public LayerMask raycastLayerMask;
    //public LayerMask enemyLayerMask;

    public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire && ammo > 0)
            //Fire();
            Shoot();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Add enemy to shoot
        Enemy wasp = other.transform.GetComponent<Enemy>();

        if (wasp)
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

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(gunDamage);
            }
        }

        nextTimeToFire = Time.time + fireRate;
        //ammo--;
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
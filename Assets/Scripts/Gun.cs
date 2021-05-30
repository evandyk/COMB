using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 20f;
    public float fireRate = .3f;
    public float weaponDamage = 2f;
    public int maxAmmo = 100;

    private int ammo = 20;
    private float nextTimeToFire;

    public Camera fpsCam;
    public AudioClip shotSound;
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        if(source == null)
            source = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire && ammo > 0)
            Shoot();
    }

    void Shoot()
    {
        source.PlayOneShot(shotSound, 0.7f);

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(weaponDamage, hit);
            }
        }

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
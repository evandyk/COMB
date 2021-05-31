using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 20f;
    public float fireRate = 3f;
    public float weaponDamage = 5f;
    public int maxAmmo = 60;

    public int ammo = 24;
    public float nextTimeToFire;

    public Camera fpsCam;
    public AudioClip shotSound;
    public AudioClip hitSound;
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

    }

    public void Shoot()
    {
        source.PlayOneShot(shotSound, 0.7f);

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                source.PlayOneShot(hitSound, 0.7f);
                target.TakeDamage(weaponDamage, hit);
            }
        }

        nextTimeToFire = Time.time + fireRate;
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Honeybonker : MonoBehaviour
{
    Animator m_Animator;

    public Camera fpsCam;
    public AudioClip bonkSound;
    public AudioClip swishSound;
    public AudioClip swipeBonkSound;
    public float bonkRange = 3f;
    public float swipeRange = 5f;
    public float fireRate = 2f;
    public float bonkDamage = 10f;
    public float swipeDamage = 2f;
    public int maxSwipeBonks = 5;

    AudioSource source;
    private float nextTimeToFire;

    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_Animator.SetTrigger("click");
            source.PlayOneShot(swishSound, 0.7f);
        }
        if (Input.GetMouseButtonDown(1))
        {
            m_Animator.SetTrigger("Rclick");
            source.PlayOneShot(swishSound, 0.7f);
        }
    }

    void Bonk()
    {
        RaycastHit hit;
        if(Physics.SphereCast(fpsCam.transform.position, .2f, fpsCam.transform.forward, out hit, bonkRange))
        {
            Target target = hit.transform.GetComponent<Target>();
            Vector3 vectorToCollider = (hit.transform.position - fpsCam.transform.position);
            vectorToCollider.Normalize();

            if (target != null && (Vector3.Dot(vectorToCollider, fpsCam.transform.forward) > 0.9f))
            {
                source.PlayOneShot(bonkSound, 0.7f);
                target.TakeDamage(bonkDamage, hit);
                if (!target.IsAlive())
                {
                    var weaponSwitch = GetComponentInParent<WeaponSwitching>();
                    weaponSwitch.kills++;
                }
                Debug.Log(hit.transform.name);
            }
        }

        nextTimeToFire = Time.time + fireRate;
    }

    void Swipe()
    {
        // 7 is Enemy Layer Mask. This prevents the player from being detected as a hit
        RaycastHit[] hits = Physics.SphereCastAll(fpsCam.transform.position, 1, fpsCam.transform.forward, swipeRange);
        if (hits != null)
        {
            List<RaycastHit> toBonk = new List<RaycastHit>();
            foreach (RaycastHit hit in hits)
            {
                Target t = hit.transform.gameObject.GetComponent<Target>();
                Vector3 vectorToCollider = (hit.transform.position - fpsCam.transform.position);
                vectorToCollider.Normalize();

                if (t != null && (Vector3.Dot(vectorToCollider, fpsCam.transform.forward) > .4) && toBonk.Count < maxSwipeBonks)
                {
                    Debug.Log("Swipe hit");
                    toBonk.Add(hit);
                }
            }

            StartCoroutine(MultiBonk(toBonk));
        }
    }

    private IEnumerator MultiBonk(List<RaycastHit> bonks)
    {
        float force = 10;

        foreach(RaycastHit bonk in bonks)
        {
            // Get the target object
            Target t = bonk.transform.gameObject.GetComponent<Target>();

            // Damage object and play sound
            source.PlayOneShot(swipeBonkSound, 0.7f);
            t.TakeDamage(swipeDamage, bonk);
            if (!t.IsAlive())
            {
                var weaponSwitch = GetComponentInParent<WeaponSwitching>();
                weaponSwitch.kills++;
            }

            // Apply force to object
            //Vector3 dir = bonk.point - transform.position;
            //dir.Normalize();
            //Rigidbody rb = bonk.transform.gameObject.GetComponent<Rigidbody>();
            //rb.AddForce(dir * force, ForceMode.Impulse);

            // Small delay to make it behave nicely
            yield return new WaitForSeconds(.05f);
        }
    }
}

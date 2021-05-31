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
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, bonkRange))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                source.PlayOneShot(bonkSound, 0.7f);
                target.TakeDamage(bonkDamage, hit);
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
        foreach(RaycastHit bonk in bonks)
        {
            Target t = bonk.transform.gameObject.GetComponent<Target>();
            source.PlayOneShot(swipeBonkSound, 0.7f);
            t.TakeDamage(swipeDamage, bonk);
            yield return new WaitForSeconds(.05f);
        }
    }
}

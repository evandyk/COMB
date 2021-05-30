using UnityEngine;

public class honeybonker : MonoBehaviour
{
    Animator m_Animator;

    public Camera fpsCam;
    public AudioClip bonkSound;
    public AudioClip swishSound;
    public float range = 5f;
    public float fireRate = 2f;
    public float weaponDamage = 10f;

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
        }
    }

    void Bonk()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                source.PlayOneShot(bonkSound, 0.7f);
                target.TakeDamage(weaponDamage, hit);
            }
        }

        nextTimeToFire = Time.time + fireRate;
    }

    void Swipe()
    {

    }
}

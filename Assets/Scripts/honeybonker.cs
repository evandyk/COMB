using UnityEngine;

public class Honeybonker : MonoBehaviour
{
    Animator m_Animator;

    public Camera fpsCam;
    public float range = 20f;
    public float fireRate = .3f;
    public float weaponDamage = 2f;

    private float nextTimeToFire;

    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_Animator.SetTrigger("click");
            Bonk();
        }
        if (Input.GetMouseButtonDown(1))
        {
            m_Animator.SetTrigger("Rclick");
            Swipe();
        }
    }

    void Bonk()
    {

    }

    void Swipe()
    {

    }
}

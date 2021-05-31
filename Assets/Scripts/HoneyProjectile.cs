using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyProjectile : MonoBehaviour
{
    Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        m_Animator.ResetTrigger("Splash");
        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.GetComponent<WaspAggro>().Unstick = Time.time + 5;
        }
    }
    public void END()
    {
        Destroy(gameObject);
    }
}

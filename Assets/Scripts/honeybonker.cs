using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class honeybonker : MonoBehaviour
{
    Animator m_Animator;
    public int poop = 0;

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
            poop = 1;
        }
    }
}

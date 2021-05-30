using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyPot : MonoBehaviour
{
    public int honeypots = 3;
    public GameObject HoneyProjectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && honeypots > 0) {
            GameObject Pot = Instantiate(HoneyProjectile, transform.position, transform.rotation);
            honeypots--;
        }
    }
}

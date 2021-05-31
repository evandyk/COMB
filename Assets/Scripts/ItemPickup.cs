using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public bool isArmor;
    public bool isAmmo;
    public bool isHoney;
    public bool isWing;
    public int amount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (isArmor)
            {
                other.GetComponent<PlayerHealth>().GiveArmor(1, gameObject);
            }

            if (isAmmo)
            {
                var weaponHolder = other.GetComponentInChildren<WeaponSwitching>();
                weaponHolder.GiveAmmo(amount, gameObject);
            }

            if (isHoney)
            {
                //other.GetComponentInChildren<Gun>().GiveHoneypot(amount, gameObject);
            }

            if (isWing)
            {

            }
        }
    }
}

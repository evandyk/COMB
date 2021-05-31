using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspBullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponentInChildren<PlayerHealth>();
            playerHealth.DamagePlayer(1);
        }
    }
}

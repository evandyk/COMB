using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int maxArmor;
    public int health;
    public int armor;

    public AudioClip ahhhhh;
    AudioSource src;

    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();
        health = maxHealth;
        armor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // test
        if(Input.GetKeyDown(KeyCode.RightShift))
        {
            DamagePlayer(1);
            Debug.Log("Player has been damaged");
        }
    }

    public void DamagePlayer(int damage)
    {
        src.PlayOneShot(ahhhhh, 0.4f);
        if(armor > 0)
        {
            armor -= damage;
            if (armor < 0)
                armor = 0;
        }
        else
        {
            health -= damage;
        }

        if(health <= 0)
        {
            // Dead
            Debug.Log("Player has died.");
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }

    public void GiveArmor(int amount, GameObject pickup)
    {
        if(armor < maxArmor)
        {
            armor += amount;
            Destroy(pickup);
        }
        else
            armor = maxArmor;
    }
}

using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public EnemyManager enemyManager;
    public Target target;
    //public float enemyHealth;
    public int spawnCount;
    //public GameObject gunHitEffect;
    private GameObject larva;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<Target>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(enemyHealth <= 0)
        //{
        //    enemyManager.RemoveEnemy(this);
        //    if (gameObject.tag == "Parasitic")
        //        SpawnLarva();
        //    Destroy(gameObject);
        //}
        if (!target.IsAlive())
        {
            if (gameObject.tag == "Parasitic")
                SpawnLarva();
            Destroy(gameObject);
        }
    }

    //public void TakeDamage(float damage)
    //{
    //    Instantiate(gunHitEffect, transform.position, Quaternion.identity);
    //    enemyHealth -= damage;
    //}

    public void SpawnLarva()
    {
        larva = new GameObject();
        for (int i = 0; i < spawnCount; i++)
            Instantiate(larva, transform.position, transform.rotation);
    }

    public void SpawnWasp()
    {
        Debug.Log("Spawn Wasp!");
    }
}
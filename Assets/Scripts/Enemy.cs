using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Target target;
    public int spawnCount;
    public GameObject larva;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<Target>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!target.IsAlive())
        {
            if (gameObject.tag == "Parasitic")
                SpawnLarva();
            Destroy(gameObject);
        }
    }

    public void SpawnLarva()
    {
        for (int i = 0; i < spawnCount; i++)
            Instantiate(larva, transform.position, transform.rotation);
    }

    public void SpawnWasp()
    {
        Debug.Log("Spawn Wasp!");
    }
}
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Target target;
    public int spawnCount;
    public GameObject larva;
    public Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        target = this.GetComponent<Target>();
        m_Animator = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            if (!target.IsAlive())
            {
                if (gameObject.tag == "Parasitic")
                {
                    m_Animator.SetTrigger("Death");
                    SpawnLarva();
                    (GetComponent("WaspAggro") as MonoBehaviour).enabled = false;
                    GetComponent<WaspAggro>().agent.SetDestination(transform.position);
                    this.enabled = false;
                }
                else
                {
                    m_Animator.SetTrigger("Death");
                    (GetComponent("WaspAggro") as MonoBehaviour).enabled = false;
                    GetComponent<WaspAggro>().agent.SetDestination(transform.position);
                }
            }
        }
    }

    public void SpawnLarva()
    {
        for (int i = 0; i < spawnCount; i++)
            Instantiate(larva, transform.position, transform.rotation);
    }
}
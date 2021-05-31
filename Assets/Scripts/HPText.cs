using UnityEngine;
using UnityEngine.UI;

public class HPText : MonoBehaviour
{
    public GameObject player;
    public Text hpText;
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = playerHealth.health.ToString();
    }
}

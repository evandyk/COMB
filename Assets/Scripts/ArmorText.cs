using UnityEngine;
using UnityEngine.UI;

public class ArmorText : MonoBehaviour
{
    //Insert link to player kill count here
    public GameObject player;
    public Text armorText;

    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        armorText.text = playerHealth.armor.ToString();
    }
}

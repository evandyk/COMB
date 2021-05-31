using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour
{
    //Insert link to player kill count here
    public GameObject gunObject;
    public Text ammoText;

    private Gun gun;

    //private Gun gun;

    // Start is called before the first frame update
    void Start()
    {
        gun = gunObject.GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = gun.ammo.ToString();
    }
}

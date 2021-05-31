using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //Insert link to player kill count here
    public GameObject player;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        //get player kill count here
        var weps = player.GetComponentInChildren<WeaponSwitching>();
        scoreText.text = "KILLS: " + weps.kills.ToString();
    }
}

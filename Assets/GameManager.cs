using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
	bool gameEnded = false;
	public float restartDelay = 1f;
	public GameObject lostMenu;
	public GameObject wonMenu;

	public void LevelComplete()
	{
		Debug.Log("GAME WON");
		wonMenu.SetActive( true);

	}

	public void LevelLost()
    {
		Debug.Log("GAME OVER");
		lostMenu.SetActive(true);
	}


	public void EndGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenus : MonoBehaviour
{
    void Start()
    {
		Time.timeScale = 1;
    }
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.N))
        {
			EndGame();
        }else if(Input.GetKeyDown(KeyCode.Y)){
			RestartGame();
        }

	}
	private void EndGame()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Confined;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	private void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
}

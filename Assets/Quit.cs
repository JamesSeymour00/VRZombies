using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{

	public void QuitApp()
	{
		SceneManager.LoadScene(0);
	}
}

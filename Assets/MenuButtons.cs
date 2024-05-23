using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
	[SerializeField] GameObject SettingsObj;
	[SerializeField] GameObject MainMenuObj;

	public void StartGame()
	{
		SceneManager.LoadScene(1);
	}

	public void Settings()
	{
		SettingsObj.SetActive(true);
		MainMenuObj.SetActive(false);
	}

	public void MainMenu()
	{
		MainMenuObj.SetActive(true);
		SettingsObj.SetActive(false);
	}

	public void Quit()
	{
		Application.Quit();
	}
}

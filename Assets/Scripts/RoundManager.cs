using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
	[SerializeField] GameObject go_button;
	private NewEnemySpawner scr_enemySpawner;

	private void Start()
	{
		scr_enemySpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<NewEnemySpawner>();
	}

	void Update()
	{
		Debug.Log(scr_enemySpawner.b_roundEnd);
		if (scr_enemySpawner.b_roundEnd)
		{
			go_button.SetActive(true);
			Debug.Log("Activating Button");
		}
		if (!scr_enemySpawner.b_roundEnd)
		{
			go_button.SetActive(false);
			Debug.Log("Deactivating Button");
		}
	}
}

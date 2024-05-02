using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CreateVectors : MonoBehaviour
{
	[SerializeField] int i_spawnPoints;
	[SerializeField] Vector3 v_offset;
	public Vector3[] v_spawnPoints;

	void Update()
	{
		Vector3[] newSpawnPoints = new Vector3[i_spawnPoints];

		for (int i = 0; i < Mathf.Min(i_spawnPoints, v_spawnPoints.Length); i++)
		{
			if (i == 0)
			{
				newSpawnPoints[i] = transform.position;
			}
			else
			{
				newSpawnPoints[i] = newSpawnPoints[i - 1] + v_offset;
			}
		}

		v_spawnPoints = newSpawnPoints;
	}
}

public class EnemySpawner : CreateVectors
{
	[SerializeField] EnemySpawnerDataSO so_enemySpawnerData;
 
	public int i_enemiesToSpawn;

	private Coroutine Spawn_CR;

	public void ActivateRound()
	{
		i_enemiesToSpawn = so_enemySpawnerData.i_enemyCount;
		if (Spawn_CR == null)
			Spawn_CR = StartCoroutine(CR_SpawnEnemies());
	}

	IEnumerator CR_SpawnEnemies()
	{
		while (i_enemiesToSpawn > 0)
		{
			i_enemiesToSpawn--;
			Vector3 selectedVector = v_spawnPoints[Random.Range(0, v_spawnPoints.Length)];

			GameObject spawnPointObject = new GameObject("SpawnPoint");
			spawnPointObject.transform.position = selectedVector;

			Instantiate(so_enemySpawnerData.go_enemyPrefab[Random.Range(0, so_enemySpawnerData.go_enemyPrefab.Length)], spawnPointObject.transform);
			yield return new WaitForSeconds(so_enemySpawnerData.f_spawnRate);
			yield return null;
		}
	}
}

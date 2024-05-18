using System.Collections;
using UnityEngine;

public class NewEnemySpawner : MonoBehaviour
{
	[SerializeField] EnemySpawnerDataSO so_enemySpawnerData;
	[SerializeField] Transform[] t_spawnPoints;
 
	private int i_enemiesToSpawn;

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

			GameObject target = Instantiate(so_enemySpawnerData.go_enemyPrefab[Random.Range(0, so_enemySpawnerData.go_enemyPrefab.Length)], t_spawnPoints[Random.Range(0, t_spawnPoints.Length)]);
			target.GetComponent<EnemyAI_Move>().SetPath();
			yield return new WaitForSeconds(so_enemySpawnerData.f_spawnRate);
		}
		Spawn_CR = null;
	}
}
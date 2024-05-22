using System.Collections;
using UnityEngine;

public class NewEnemySpawner : MonoBehaviour
{
	[SerializeField] EnemySpawnerDataSO so_enemySpawnerData;
	[SerializeField] Transform[] t_spawnPoints;
 
	public int i_enemiesToSpawn;
	public int i_enemiesToKill;
	public bool b_roundEnd;

	private Coroutine Spawn_CR;

	private void Start()
	{
		b_roundEnd = true;
		i_enemiesToSpawn = so_enemySpawnerData.i_enemyCount;
		i_enemiesToKill = i_enemiesToSpawn;
	}

	public void ActivateRound()
	{
		if (Spawn_CR == null)
			Spawn_CR = StartCoroutine(CR_SpawnEnemies());
	}

	private void Update()
	{
		if (i_enemiesToKill <= 0)
		{
			b_roundEnd = true;
		}
	}

	IEnumerator CR_SpawnEnemies()
	{
		b_roundEnd = false;
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
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnerData", order = 1)]
public class EnemySpawnerDataSO : ScriptableObject
{
	public int i_enemyCount;
	public float f_spawnRate;
	public GameObject[] go_enemyPrefab;
}

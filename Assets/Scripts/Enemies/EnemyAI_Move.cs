using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI_Move : MonoBehaviour
{
	[SerializeField] EnemyAI_Data so_enemyData;

	public NavMeshAgent nm_enemy;
	public Transform t_playerPos;
	public Collider c_playerCol;

	private bool b_canSeePlayer;

	private Coroutine MoveEnemy_CR;

	private void Start()
	{
		nm_enemy = GetComponent<NavMeshAgent>();
		t_playerPos = GameObject.FindGameObjectWithTag("Player").transform;
		c_playerCol = t_playerPos.gameObject.GetComponent<Collider>();

		nm_enemy.speed = so_enemyData.f_enemySpeed;
	}

	private void Update()
	{
		nm_enemy.SetDestination(t_playerPos.position);
		RadiusCheck();
	}

	void RadiusCheck()
	{
		if (Vector3.Magnitude(t_playerPos.position - transform.position) <= so_enemyData.f_perceptionRadius)
		{
			b_canSeePlayer = true;
			if (MoveEnemy_CR == null)
				MoveEnemy_CR = StartCoroutine(CR_MoveEnemy());
		}
		else
		{
			b_canSeePlayer = false;
			MoveEnemy_CR = null;
			nm_enemy.speed = so_enemyData.f_enemySpeed;
		}
	}

	IEnumerator CR_MoveEnemy()
	{
		while (b_canSeePlayer)
		{
			nm_enemy.speed = so_enemyData.f_enemySpeed * 2.5f;
			yield return null;
		}
	}
}
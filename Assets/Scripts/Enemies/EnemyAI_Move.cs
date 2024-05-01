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

	private void Start()
	{
		nm_enemy = GetComponent<NavMeshAgent>();
		t_playerPos = GameObject.FindGameObjectWithTag("Player").transform;
		c_playerCol = t_playerPos.gameObject.GetComponent<Collider>();

		nm_enemy.speed = so_enemyData.f_enemySpeed;
	}

	private void OnTriggerStay(Collider other)
	{
		Debug.Log("Collision");
		if (other == c_playerCol)
		{
			nm_enemy.SetDestination(t_playerPos.position);
			Debug.Log("Warping");
		}
	}
}
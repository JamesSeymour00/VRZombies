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

	public Transform t_pathingTarget;
	public GameObject[] t_doors;
	public Transform t_selectedDoor;
	private float oldDistance;

	public bool b_hasReachedDoor;

	private void Awake()
	{
		t_doors = GameObject.FindGameObjectsWithTag("Door");
		nm_enemy = GetComponent<NavMeshAgent>();
		t_playerPos = GameObject.FindGameObjectWithTag("Player").transform;
		c_playerCol = t_playerPos.gameObject.GetComponent<Collider>();

		nm_enemy.speed = so_enemyData.f_enemySpeed;
		FindClosestDoor();
		SetPath();
	}

	private void Update()
	{
		nm_enemy.SetDestination(t_pathingTarget.position);
		RadiusCheck();
	}

	private void FindClosestDoor()
	{
		for (int i = 0; i < t_doors.Length; i++)
		{
			Debug.Log("Looping... currently at door number [" + i + "]");
			float newDistance = Vector3.Magnitude(t_doors[i].transform.position - transform.position);
			if (oldDistance == 0)
			{
				oldDistance = newDistance;
				t_selectedDoor = t_doors[i].transform;
			}			
			if (newDistance < oldDistance)
			{
				oldDistance = newDistance;
				t_selectedDoor = t_doors[i].transform;
			}
		}
	}

	public void SetPath()
	{
		if (!b_hasReachedDoor)
		{
			t_pathingTarget = t_selectedDoor;
		}
		else
			t_pathingTarget = t_playerPos;
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
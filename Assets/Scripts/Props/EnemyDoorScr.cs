using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoorScr : MonoBehaviour
{
	[SerializeField] Transform t_portal1;
	[SerializeField] Transform t_portal2;


	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			if (Vector3.Magnitude(other.transform.position - t_portal1.transform.position) < Vector3.Magnitude(other.transform.position - t_portal2.transform.position))
			{
				other.transform.position = t_portal2.transform.position;
				other.GetComponent<EnemyAI_Move>().b_hasReachedDoor = true;
				other.GetComponent<EnemyAI_Move>().SetPath();
			}
			else
			{
				other.transform.position = t_portal1.transform.position;
				other.GetComponent<EnemyAI_Move>().b_hasReachedDoor = true;
				other.GetComponent<EnemyAI_Move>().SetPath();
			}
		}
	}
}

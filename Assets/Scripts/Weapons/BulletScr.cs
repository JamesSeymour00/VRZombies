using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScr : MonoBehaviour
{
	[SerializeField] BulletDataSO so_bulletData;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			Debug.Log("Hit Enemy!");
			other.gameObject.GetComponent<EnemyAI_Health>().TakeDamage(so_bulletData.f_bulletDamage);
			Destroy(gameObject);
		}
		else if (other.gameObject.tag != "Weapon")
		{
			Debug.Log(other.gameObject.name);
			Destroy(gameObject);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			Debug.Log("Hit Enemy!");
			other.gameObject.GetComponent<EnemyAI_Health>().TakeDamage(so_bulletData.f_bulletDamage);
			Destroy(gameObject);
		}
		else if (other.gameObject.tag != "Weapon")
		{
			Debug.Log(other.gameObject.name);
			Destroy(gameObject);
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			Debug.Log("Hit Enemy!");
			other.gameObject.GetComponent<EnemyAI_Health>().TakeDamage(so_bulletData.f_bulletDamage);
			Destroy(gameObject);
		}
		else if (other.gameObject.tag != "Weapon")
		{
			Debug.Log(other.gameObject.name);
			Destroy(gameObject);
		}
	}
}

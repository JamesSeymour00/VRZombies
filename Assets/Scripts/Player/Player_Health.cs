using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
	[SerializeField] float f_currentHealth;
	[SerializeField] float f_maxHealth;

	private void Start()
	{
		f_currentHealth = f_maxHealth;
	}

	public void TakeDamage(float damage)
	{
		if (f_currentHealth > 0 )
		{
			f_currentHealth -= damage;
		}
		else if (f_currentHealth <= 0)
		{
			f_currentHealth = 0;
			StartCoroutine(PlayerDie());
		}
	}

	IEnumerator PlayerDie()
	{
		yield return null;
	}
}

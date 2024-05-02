using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI_Health : MonoBehaviour
{
	[SerializeField] EnemyAI_Data so_enemyData;
	[SerializeField] Image i_enemyUI;

	public float f_enemyHealth;

	private void Start()
	{
		f_enemyHealth = so_enemyData.f_enemyHealth;
	}

	public void TakeDamage(float dmg)
	{
		if (f_enemyHealth > 0)
		{
			f_enemyHealth -= dmg;
			UpdateUI();
		}
		else if (f_enemyHealth <= 0)
		{
			EnemyDie();
		}
	}

	void UpdateUI()
	{
		i_enemyUI.fillAmount = f_enemyHealth / so_enemyData.f_enemyHealth;
	}

	void EnemyDie()
	{
		Destroy(gameObject);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI_Health : MonoBehaviour
{
	[SerializeField] EnemyAI_Data so_enemyData;
	[SerializeField] Image i_enemyUI;
	private MoneySystem scr_GM_moneySystem;

	public float f_enemyHealth;

	private void Start()
	{
		f_enemyHealth = so_enemyData.f_enemyHealth;
		scr_GM_moneySystem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MoneySystem>();
	}

	public void TakeDamage(float dmg)
	{
		if (f_enemyHealth <= 0)
		{
			f_enemyHealth = 0;
			UpdateUI();
			EnemyDie();
		}
		else if (f_enemyHealth > 0)
		{
			f_enemyHealth -= dmg;
			scr_GM_moneySystem.AddMoney(so_enemyData.f_moneyPerShot);
			UpdateUI();
		}
	}

	void UpdateUI()
	{
		i_enemyUI.fillAmount = f_enemyHealth / so_enemyData.f_enemyHealth;
	}

	void EnemyDie()
	{
		scr_GM_moneySystem.AddMoney(so_enemyData.f_moneyPerDeath);
		Destroy(gameObject);
	}
}

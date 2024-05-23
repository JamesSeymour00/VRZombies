using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
	[SerializeField] PriceListSO SO_PricesData;
	[SerializeField] Transform SpawnPoint;
	private MoneySystem scr_moneySystem;

	private void Awake()
	{
		scr_moneySystem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MoneySystem>();
	}

	public void BuyM4Mag()
	{
		if (scr_moneySystem.f_currentMoney >= SO_PricesData.M4Mag)
		{
			scr_moneySystem.f_currentMoney -= SO_PricesData.M4Mag;
			Instantiate(SO_PricesData.M4MagObj, SpawnPoint);
		}
	}

	public void BuyP250Mag()
	{
		if (scr_moneySystem.f_currentMoney >= SO_PricesData.P250Mag)
		{
			scr_moneySystem.f_currentMoney -= SO_PricesData.P250Mag;
			Instantiate(SO_PricesData.P250MagObj);
		}
	}
}

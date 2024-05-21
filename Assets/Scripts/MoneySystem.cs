using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneySystem : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI t_moneyText;
	private float f_currentMoney;
	private float f_startingMoney;

	private void Start()
	{
		f_currentMoney = f_startingMoney;
	}

	public void AddMoney(float add)
	{
		f_currentMoney =+ add;
		UpdateUI();
	}

	public void SpendMoney(float remove)
	{
		f_currentMoney =- remove;
		UpdateUI();
	}

	private void UpdateUI()
	{
		t_moneyText.text = f_currentMoney.ToString();
	}
}
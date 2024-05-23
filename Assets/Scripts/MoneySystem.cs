using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneySystem : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI t_moneyText;
	public float f_currentMoney;
	private float f_startingMoney = 500;

	private void Start()
	{
		f_currentMoney = f_startingMoney;
		UpdateUI();
	}

	public void AddMoney(float add)
	{
		f_currentMoney += add;
		UpdateUI();
	}

	public void SpendMoney(float remove)
	{
		f_currentMoney -= remove;
		UpdateUI();
	}

	public void UpdateUI()
	{
		t_moneyText.text = f_currentMoney.ToString();
	}
}
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PriceListData", order = 1)]
public class PriceListSO : ScriptableObject
{
	public GameObject M4MagObj;
	public GameObject P250MagObj;
	public float M4Mag;
	public float P250Mag;
}
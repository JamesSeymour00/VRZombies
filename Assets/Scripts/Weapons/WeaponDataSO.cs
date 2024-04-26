using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponDataSO : ScriptableObject
{
	public float f_bulletSpeed = 100f;
	public float f_effectiveRange = 1000f;
	public float f_reloadSpeed = 2.5f;
}
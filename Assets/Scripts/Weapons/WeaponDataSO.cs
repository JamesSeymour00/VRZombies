using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponDataSO : ScriptableObject
{
	public float f_effectiveRange = 550f;
	public float f_fireRate = 0.09f;
	public GameObject pe_muzzleFlash;
	public float f_muzzleFlashDuration;
}
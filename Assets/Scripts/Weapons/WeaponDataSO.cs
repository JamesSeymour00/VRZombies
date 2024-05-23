using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponDataSO : ScriptableObject
{
	public float f_fireRate;
	public float f_bulletSpeed;
	public float f_casingSpeed;
	public float f_spinForce;
	public GameObject pe_muzzleFlash;
	public GameObject go_bulletPrefab;
	public GameObject go_bulletCasing;
	public float f_muzzleFlashDuration;
	public AudioClip ac_shootFX;

	// OPTIONAL

	public float f_effectiveRange;
	public float f_bulletDamage;
}
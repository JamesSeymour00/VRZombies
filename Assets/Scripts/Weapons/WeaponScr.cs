using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScr : MonoBehaviour
{
	[SerializeField] Transform t_gunTip;
	[SerializeField] Transform t_sightTip;
	[SerializeField] WeaponDataSO so_weaponData;
	[SerializeField] LayerMask l_IgnoreHoldItem;
	[SerializeField, Range(0f, 1f)] float f_weaponVolume;
	[HideInInspector] public float f_fireRate;
	private AudioSource as_source;
	public MagazineScr scr_mag;
	private int i_grabs;
	private bool b_magAttached;
	private GameObject ShootingTarget;
	public bool b_isHeld;

	private void Update()
	{
		Debug.DrawRay(t_gunTip.position, t_gunTip.forward, Color.blue);
		Debug.DrawRay(transform.position, transform.forward * -1, Color.red);
	}

	private void OnEnable()
	{
		f_fireRate = so_weaponData.f_fireRate;
		as_source = GetComponent<AudioSource>();
	}

	#region SHOOT
	public void Shoot()
	{
		if (b_magAttached)
		{
			if (scr_mag.i_AmmoCount > 0)
			{
				StartCoroutine(ShootVFX_CR());
				scr_mag.i_AmmoCount--;
				scr_mag.UpdateMagUI();

				if (Physics.Raycast(t_sightTip.position, t_sightTip.forward, out RaycastHit hitInfo))
				{
					ShootingTarget = hitInfo.collider.gameObject;

					Raycast();
				}
				else
					return;
				

				//GameObject Bullet = Instantiate(so_weaponData.go_bulletPrefab, t_gunTip.position, t_gunTip.rotation);
				//Bullet.GetComponent<Rigidbody>().AddForce(t_gunTip.forward * so_weaponData.f_bulletSpeed, ForceMode.Impulse);
			}
		}
	}

	private void Raycast()
	{
		if (ShootingTarget.GetComponent<EnemyAI_Health>())
		{
			EnemyAI_Health Target = ShootingTarget.GetComponent<EnemyAI_Health>();
			Target.TakeDamage(so_weaponData.f_bulletDamage);
			Debug.Log(Target.name);
		}
		else
			return;
	}
	#endregion

	#region MAGAZINE
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Ammo")
		{
			if (b_magAttached)
			{
				scr_mag = other.GetComponent<MagazineScr>();
			}
		}
	}

	public void AttachMag()
	{
		b_magAttached = true;
	}

	public void EjectMag()
	{
		b_magAttached = false;
		scr_mag = null;
	}
	#endregion

	#region WEAPON HOLDING/RELEASING
	public void HoldWeapon()
	{
		if (Physics.Raycast(transform.position, transform.forward * -1, 15f, l_IgnoreHoldItem) != true)
		{
			i_grabs++;
			b_isHeld = true;
		}
	}
	public void ReleaseWeapon()
	{
		if (Physics.Raycast(transform.position, transform.forward * -1, 15f, l_IgnoreHoldItem) != true && i_grabs == 1)
		{
			i_grabs--;
			b_isHeld = false;
		}
		else
		{
			i_grabs = 1;
			b_isHeld = true;
		}
	}
	#endregion

	#region Weapon VFX

	IEnumerator ShootVFX_CR()
	{
		GameObject flash = Instantiate(so_weaponData.pe_muzzleFlash, t_gunTip.position, t_gunTip.rotation);
		as_source.PlayOneShot(so_weaponData.ac_shootFX, f_weaponVolume);
		yield return new WaitForSeconds(so_weaponData.f_muzzleFlashDuration);
		Destroy(flash);
	}

	#endregion
}
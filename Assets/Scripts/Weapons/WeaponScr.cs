using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScr : MonoBehaviour
{
	[SerializeField] Transform t_gunTip;
	[SerializeField] WeaponDataSO scr_data;
	[SerializeField] LayerMask l_IgnoreHoldItem;
	private MagazineScr scr_mag;
	public bool b_magAttached;
	public bool b_isHeld;

	private void Update()
	{
		Debug.DrawRay(t_gunTip.position, t_gunTip.up);
		Debug.DrawRay(transform.position, transform.forward * -1, Color.red);
	}

	public void Shoot()
	{
		if (scr_mag.i_AmmoCount > 0 && b_magAttached)
		{
			if (Physics.Raycast(t_gunTip.position, t_gunTip.up, out RaycastHit hitInfo, scr_data.f_effectiveRange))
			{
				Debug.Log(hitInfo.transform.name);
				scr_mag.i_AmmoCount--;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (b_magAttached)
		{
			scr_mag = other.GetComponent<MagazineScr>();
		}
	}

	public void AttachMag()
	{
		Debug.Log("Attaching mag");
		b_magAttached = true;
	}

	public void EjectMag()
	{
		Debug.Log("Ejecting mag");
		b_magAttached = false;
	}

	public void HoldWeapon()
	{
		if (Physics.Raycast(transform.position, transform.forward * -1, 10f, l_IgnoreHoldItem) != true)
		{
			Debug.Log("Holding weapon");
			b_isHeld = true;
		}
	}
	public void ReleaseWeapon()
	{
		if (Physics.Raycast(transform.position, transform.forward * -1, 10f, l_IgnoreHoldItem) != true)
		{
			Debug.Log("Releasing weapon");
			b_isHeld = false;
		}
		else b_isHeld = true;
	}
}
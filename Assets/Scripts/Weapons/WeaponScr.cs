using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponScr : MonoBehaviour
{
	[SerializeField] Transform t_gunTip;
	[SerializeField] WeaponDataSO scr_data;
	[SerializeField] LayerMask l_IgnoreHoldItem;
	[SerializeField] int grabs;
	private MagazineScr scr_mag;
	public float f_fireRate;
	public bool b_magAttached;
	public bool b_isHeld;

	private void Update()
	{
		Debug.DrawRay(t_gunTip.position, t_gunTip.up);
		Debug.DrawRay(transform.position, transform.forward * -1, Color.red);
	}

	private void OnEnable()
	{
		f_fireRate = scr_data.f_fireRate;
	}

	#region SHOOT
	public void Shoot()
	{
		if (scr_mag.i_AmmoCount > 0 && b_magAttached)
		{
			if (Physics.Raycast(t_gunTip.position, t_gunTip.up, out RaycastHit hitInfo, scr_data.f_effectiveRange))
			{
				Debug.Log(hitInfo.transform.name);
				scr_mag.i_AmmoCount--;
				scr_mag.UpdateMagUI();
			}
		}
	}
	#endregion

	#region MAGAZINE
	private void OnTriggerStay(Collider other)
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
		scr_mag = null;
	}
	#endregion

	#region WEAPON HOLDING/RELEASING
	public void HoldWeapon()
	{
		if (Physics.Raycast(transform.position, transform.forward * -1, 10f, l_IgnoreHoldItem) != true)
		{
			grabs++;
			Debug.Log("Holding weapon");
			b_isHeld = true;
		}
	}
	public void ReleaseWeapon()
	{
		if (Physics.Raycast(transform.position, transform.forward * -1, 10f, l_IgnoreHoldItem) != true && grabs == 1)
		{
			grabs--;
			Debug.Log("Releasing weapon");	
			b_isHeld = false;
		}
		else 
		{
			grabs = 1;
			b_isHeld = true;
		}		
	}
	#endregion
}
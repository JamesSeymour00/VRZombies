using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSocket : MonoBehaviour
{
	private WeaponScr scr_Weapon;
	private bool b_fireDebug;

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "P250" || other.tag == "M4")
		{
			scr_Weapon = other.GetComponent<WeaponScr>();
		}
	}

	public void HoldWeapon()
	{
		if (scr_Weapon != null)
		{
			scr_Weapon.i_grabs = 0;
			scr_Weapon.b_isHeld = false;
		}
	}

	public void ReleaseWeapon()
	{
		if (scr_Weapon != null)
		{
			scr_Weapon.i_grabs = 1;
			scr_Weapon.b_isHeld = true;
		}
	}
}
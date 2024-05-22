using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHolster : MonoBehaviour
{
	private WeaponScr scr_Weapon;
	private bool b_fireDebug;

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "P250")
		{
			scr_Weapon = other.GetComponent<WeaponScr>();
		}
	}

	public void Holster_Gun()
	{
		if (scr_Weapon != null)
		{
			scr_Weapon.b_isHeld = false;
		}
	}

	//public void Give_Weapon()
	//{
	//	if (scr_Weapon != null)
	//	{
	//		scr_Weapon.b_isHeld = true;
	//	}
	//}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandScr : MonoBehaviour
{
	private WeaponScr scr_Weapon;

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Weapon")
		{
			scr_Weapon = other.GetComponent<WeaponScr>();
		}
	}

	public void Hold_Weapon()
	{
		if (scr_Weapon != null)
		{
			scr_Weapon.b_isHeld = false;
		}		
	}

	public void Give_Weapon()
	{
		if (scr_Weapon != null)
		{
			scr_Weapon.b_isHeld = true;
		}
	}
}

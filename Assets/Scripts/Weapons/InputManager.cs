using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
	private VRControls scr_inputActions;

	GameObject[] g_PossibleWeapons;
	WeaponScr g_SelectedWeapon;

	private Coroutine CR_Shoot;

	private bool b_triggerHold;
	private bool b_fireMode;

	private void Awake()
	{
		scr_inputActions = new VRControls();
		b_fireMode = false;
		CR_Shoot = null;
	}

	private void OnEnable()
	{
		scr_inputActions.VRPlayer.Shoot.performed += ShootPerformed;
		scr_inputActions.VRPlayer.Shoot.canceled += ShootCanceled;
		scr_inputActions.VRPlayer.Shoot.Enable();

		scr_inputActions.VRPlayer.FireMode.performed += FireModePerformed;
		scr_inputActions.VRPlayer.FireMode.Enable();
	}

	private void OnDisable()
	{
		scr_inputActions.VRPlayer.Shoot.performed -= ShootPerformed;
		scr_inputActions.VRPlayer.Shoot.canceled -= ShootCanceled;
		scr_inputActions.VRPlayer.Shoot.Disable();

		scr_inputActions.VRPlayer.FireMode.performed -= FireModePerformed;
		scr_inputActions.VRPlayer.FireMode.Disable();

	}

	private void ShootPerformed(InputAction.CallbackContext context)
	{
		FindHeldWeapon();
		b_triggerHold = true;
		if (b_fireMode)
		{
			if (CR_Shoot == null)
			{
				float delay = g_SelectedWeapon.GetComponent<WeaponScr>().f_fireRate;
				CR_Shoot = StartCoroutine(Shoot_CR(delay));
			}
		}
		else 
		{
			g_SelectedWeapon.Shoot();
		}	
	}

	private void ShootCanceled(InputAction.CallbackContext context)
	{
		b_triggerHold = false;
		if (CR_Shoot != null)
		{
			StopCoroutine(CR_Shoot);
			CR_Shoot = null;
		}
	}

	private void FireModePerformed(InputAction.CallbackContext context)
	{
		b_fireMode = !b_fireMode;
	}


	public void FindHeldWeapon()
	{
		g_PossibleWeapons = GameObject.FindGameObjectsWithTag("Weapon");

		for (int i = 0; i < g_PossibleWeapons.Length; i++)
		{
			if (g_PossibleWeapons[i].GetComponent<WeaponScr>().b_isHeld == true)
			{
				g_SelectedWeapon = g_PossibleWeapons[i].GetComponent<WeaponScr>();
				return;
			}
		}
	}

	IEnumerator Shoot_CR(float delay)
	{
		while (b_triggerHold)
		{
			g_SelectedWeapon.Shoot();
			yield return new WaitForSeconds(delay);
			//yield return null;
		}
	}
}
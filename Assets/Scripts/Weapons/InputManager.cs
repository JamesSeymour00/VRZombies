using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class InputManager : MonoBehaviour
{
	private VRControls scr_inputActions;

	GameObject[] g_PossibleWeapons;
	WeaponScr g_SelectedWeapon;

	private void Awake()
	{
		scr_inputActions = new VRControls();
	}

	private void OnEnable()
	{
		scr_inputActions.VRPlayer.Shoot.performed += ShootPerformed;
		scr_inputActions.VRPlayer.Shoot.Enable();
	}

	private void OnDisable()
	{
		scr_inputActions.VRPlayer.Shoot.performed -= ShootPerformed;
		scr_inputActions.VRPlayer.Shoot.Disable();
	}

	private void ShootPerformed(InputAction.CallbackContext context)
	{
		FindHeldWeapon();
	}

	public void FindHeldWeapon()
	{
		g_PossibleWeapons = GameObject.FindGameObjectsWithTag("Weapon");

		for (int i = 0; i < g_PossibleWeapons.Length; i++)
		{
			if (g_PossibleWeapons[i].GetComponent<WeaponScr>().b_isHeld == true)
			{
				g_SelectedWeapon = g_PossibleWeapons[i].GetComponent<WeaponScr>();
				g_SelectedWeapon.Shoot();
				return;
			}
		}
	}
}
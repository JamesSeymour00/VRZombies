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
	private VRControls _inputActions;

	GameObject[] PossibleWeapons;
	WeaponScr SelectedWeapon;

	private void Awake()
	{
		_inputActions = new VRControls();
	}

	private void OnEnable()
	{
		_inputActions.VRPlayer.Shoot.performed += ShootPerformed;
		_inputActions.VRPlayer.Shoot.Enable();
	}

	private void OnDisable()
	{
		_inputActions.VRPlayer.Shoot.performed -= ShootPerformed;
		_inputActions.VRPlayer.Shoot.Disable();
	}

	private void ShootPerformed(InputAction.CallbackContext context)
	{
		FindHeldWeapon();
	}

	public void FindHeldWeapon()
	{
		PossibleWeapons = GameObject.FindGameObjectsWithTag("Weapon");

		for (int i = 0; i < PossibleWeapons.Length; i++)
		{
			if (PossibleWeapons[i].GetComponent<WeaponScr>()._isHeld == true)
			{
				SelectedWeapon = PossibleWeapons[i].GetComponent<WeaponScr>();
				SelectedWeapon.Shoot();
				return;
			}
		}
	}
}
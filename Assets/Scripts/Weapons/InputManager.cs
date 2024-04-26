using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
	//private VRControls _inputActions;
	//public bool _shoot;
	//Coroutine _ShootCR;

	//private void Awake()
	//{
	//	_inputActions = new VRControls();
	//}

	//private void OnEnable()
	//{
	//	_inputActions.Player.Shoot.performed += ShootPerformed;
	//	_inputActions.Player.Shoot.Enable();
	//}

	//private void OnDisable()
	//{
	//	_inputActions.Player.Shoot.performed -= ShootPerformed;
	//	_inputActions.Player.Shoot.Disable();
	//}

	//private void ShootPerformed(InputAction.CallbackContext context)
	//{
	//	Debug.Log(context);
	//	if (_ShootCR == null)
	//	{
	//		_shoot = true;
	//		_ShootCR = StartCoroutine(Shoot_CR());
	//	}
	//}

	//IEnumerator Shoot_CR()
	//{
	//	yield return new WaitForSeconds(0.01f);
	//	_shoot = false;
	//	_ShootCR = null;
	//}
}
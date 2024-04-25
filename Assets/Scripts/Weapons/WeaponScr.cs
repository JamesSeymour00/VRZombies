using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScr : MonoBehaviour
{
	[SerializeField] GameObject _projectile;
	[SerializeField] Transform _gunTip;
	[SerializeField] WeaponDataSO _data;
	private InputManager PlayerInput;
	private Rigidbody _bulletRB;

	private void Awake()
	{
		PlayerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<InputManager>();
	}

	private void Update()
	{
		if (PlayerInput._shoot == true)
		{
			Shoot();
		}
	}

	private void Shoot()
	{
		GameObject Bullet = Instantiate(_projectile, _gunTip.position, _gunTip.rotation);
		_bulletRB = Bullet.GetComponent<Rigidbody>();
		_bulletRB.AddForce(_projectile.transform.forward * _data._bulletSpeed, ForceMode.Impulse);
	}
}

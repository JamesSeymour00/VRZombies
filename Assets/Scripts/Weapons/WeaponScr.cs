using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScr : MonoBehaviour
{
	[SerializeField] Transform _gunTip;
	[SerializeField] WeaponDataSO _data;
	public bool _isHeld;

	private void Update()
	{
		Debug.DrawRay(_gunTip.position, _gunTip.up);
	}

	public void Shoot()
	{
		if (Physics.Raycast(_gunTip.position, _gunTip.up, out RaycastHit hitInfo /*, _data._MaxGunRange*/))
		{
			Debug.Log(hitInfo.transform.name);
		}

		OnGunShot();
	}
	void OnGunShot()
	{

	}

	public void HoldWeapon()
	{
		_isHeld = true;
	}
	public void ReleaseWeapon()
	{
		_isHeld = false;
	}
}

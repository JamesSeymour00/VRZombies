using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineScr : MonoBehaviour
{
	[SerializeField] MagazineDataSO scr_MagData;
	public int i_AmmoCount;

	private void OnEnable()
	{
		i_AmmoCount = scr_MagData.i_AmmoCount;
	}
}

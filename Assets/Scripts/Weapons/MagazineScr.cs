using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MagazineScr : MonoBehaviour
{
	[SerializeField] MagazineDataSO scr_MagData;
	[SerializeField] Image img_filler;
	[SerializeField] TextMeshProUGUI t_ammoText;
	
	public int i_AmmoCount;
	public bool b_exitPouch;

	private void OnEnable()
	{
		i_AmmoCount = scr_MagData.i_AmmoCount;
		b_exitPouch = false;

		UpdateMagUI();

		if (img_filler == null || t_ammoText == null || scr_MagData == null)
		{
			Debug.LogError("Missing components! Assign scriptable objects and/or UI elements!");
		}
	}

	public void UpdateMagUI()
	{
		t_ammoText.text = (i_AmmoCount + (" / ") + scr_MagData.i_AmmoCount);
		img_filler.fillAmount = (float)i_AmmoCount / (float)scr_MagData.i_AmmoCount;
	}
}

using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.XR.Interaction.Toolkit;

public class AmmoPouchScr : MonoBehaviour
{
	[SerializeField] LayerMask lm_AcceptedLayer;
	[SerializeField] GameObject Spawner;
	public int i_magCount;
	private GameObject go_TargetAmmo;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Ammo" && !go_TargetAmmo)
		{
			go_TargetAmmo = other.gameObject;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Ammo" && go_TargetAmmo)
		{
			go_TargetAmmo = null;
		}
	}

	public void StoreAmmo()
	{
		Destroy(go_TargetAmmo);
		Spawner.gameObject.SetActive(true);
		go_TargetAmmo = null;
		i_magCount++;
	}

	//public void ReduceMagCount()
	//{
	//	if (i_magCount <= 0) 
	//	{
	//		Spawner.gameObject.SetActive(false);
	//		i_magCount--;
	//	} 
	//}
}
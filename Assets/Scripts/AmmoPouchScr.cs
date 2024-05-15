using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AmmoPouchScr : XRSocketInteractor
{
	public int i_magCount;

	protected override void OnSelectEntered(SelectEnterEventArgs args)
	{
		base.OnSelectEntered(args);

		Transform selectedObjectTransform = args.interactableObject.transform;

		if (selectedObjectTransform.CompareTag("Ammo"))
		{
			Debug.Log("Ammo placed on the socket!");
			i_magCount++;
			Destroy(selectedObjectTransform.gameObject);
		}
	}

	protected override void OnHoverExited(HoverExitEventArgs args)
	{
		base.OnHoverExited(args);

		Transform hoveredObjectTransform = args.interactableObject.transform;

		bool HasExited = hoveredObjectTransform.GetComponent<MagazineScr>().b_exitPouch;

		if (!HasExited)
		{
			// REDUCE THE AMOUNT OF AMMO
			i_magCount--;
			if (i_magCount < 0)
				i_magCount = 0;

			// DESTROY THE OBJECT IF THE PLAYER DOESNT HAVE AMMO
			if (hoveredObjectTransform.CompareTag("Ammo") && i_magCount <= 0)
				Destroy(hoveredObjectTransform.gameObject);
		}	

		hoveredObjectTransform.GetComponent<MagazineScr>().b_exitPouch = true;
	}
}
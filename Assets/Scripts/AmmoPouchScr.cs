using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AmmoPouchScr : XRSocketInteractor
{
	public int i_magCount;

	[SerializeField] string _acceptedTag;

	// Generate the visual mesh if true
	public override bool CanHover(IXRHoverInteractable interactable)
	{
		if (!base.CanHover(interactable)) return false;

		if (interactable.transform.tag == _acceptedTag) return true;

		return false;
	}

	// Attaches obejct to socket if true
	public override bool CanSelect(IXRSelectInteractable interactable)
	{
		if (!base.CanSelect(interactable)) return false;

		if (interactable.transform.tag == _acceptedTag) return true;
		return false;
	}

	protected override void OnSelectEntered(SelectEnterEventArgs args)
	{
        base.OnSelectEntered(args);

        GameObject EnteredItem = args.interactableObject.transform.gameObject;

        if (EnteredItem.GetComponent<MagazineScr>().b_exitPouch == true && EnteredItem.CompareTag("Ammo"))
		{
            Debug.Log("Ammo placed on the socket!");
            i_magCount++;
            Destroy(EnteredItem);
        }       
    }

	protected override void OnHoverExited(HoverExitEventArgs args)
	{
		base.OnHoverExited(args);

        if (args.interactableObject.transform.GetComponent<MagazineScr>().b_exitPouch == false)
		{
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
}
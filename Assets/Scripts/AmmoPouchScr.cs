using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AmmoPouchScr : XRSocketInteractor
{
	public int i_magCount;
    public XRInfiniteInteractable AmmoSpawnerScr;

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

	private void Update()
	{
		if (i_magCount == 0)
		{
            AmmoSpawnerScr.b_canPlaceMag = false;

        }
        else AmmoSpawnerScr.b_canPlaceMag = true;
    }

	protected override void OnSelectEntered(SelectEnterEventArgs args)
	{
        base.OnSelectEntered(args);

        if (args.interactableObject.transform.CompareTag("Ammo") && args.interactableObject.transform.gameObject.GetComponent<MagazineScr>().b_exitPouch)
		{
            Debug.Log("Ammo placed on the socket!");
            i_magCount++;
            Destroy(args.interactableObject.transform.gameObject);
        }       
    }

	protected override void OnHoverExited(HoverExitEventArgs args)
	{
		base.OnHoverExited(args);

        if (args.interactableObject.transform.CompareTag("Ammo") && !args.interactableObject.transform.gameObject.GetComponent<MagazineScr>().b_exitPouch)
		{
            args.interactableObject.transform.gameObject.GetComponent<MagazineScr>().b_exitPouch = true;
            i_magCount--;
            Debug.Log("Ammo removed on the socket!");
            if (i_magCount < 0)
                i_magCount = 0;
        }  
    }        
}
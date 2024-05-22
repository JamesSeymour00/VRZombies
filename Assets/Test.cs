using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Test : XRSocketInteractor
{
	protected override void OnSelectEntered(SelectEnterEventArgs args)
	{
		base.OnSelectEntered(args); // Ensure proper functionality
		Debug.Log("OnSelectEntered triggered"); // Debug log to check method call
		Debug.Log(args.interactableObject.transform.gameObject.name); // Log the name of the interactable object
	}
}
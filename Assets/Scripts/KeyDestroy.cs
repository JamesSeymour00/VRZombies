using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyDestroy : MonoBehaviour
{
	XRExclusiveSocket _socket;

	private void Awake()
	{
		_socket = GetComponent<XRExclusiveSocket>();
		Assert.IsNotNull(_socket);

		_socket.selectEntered.AddListener(OnSelectEntered);
	}

	void OnSelectEntered(SelectEnterEventArgs args)
	{
		GameObject other = args.interactableObject.transform.gameObject;
		Destroy(other);
	}
}
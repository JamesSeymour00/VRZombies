using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.XR.Interaction.Toolkit;

public class IgnoreCollisionsWithSocket : MonoBehaviour
{
	XRExclusiveSocket _socket;

	[SerializeField]
	Collider _ourCollider = null;
	Collider _theirCollider;

	private void Awake()
	{
		_socket = GetComponent<XRExclusiveSocket>();
		Assert.IsNotNull(_socket);

		_ourCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>();

		_socket.selectEntered.AddListener(OnSelectEntered);
		_socket.selectExited.AddListener(OnSelectExited);
	}

	void OnSelectEntered(SelectEnterEventArgs args)
	{
		GameObject other = args.interactableObject.transform.gameObject;
		_theirCollider = other.GetComponent<Collider>();

		Physics.IgnoreCollision(_ourCollider, _theirCollider, true);
	}

	void OnSelectExited(SelectExitEventArgs args)
	{
		Physics.IgnoreCollision(_ourCollider, _theirCollider, false);
	}
}
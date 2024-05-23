using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyDestroy : MonoBehaviour
{
	XRExclusiveSocket _socket;

	private void Awake()
	{
		_socket = GetComponent<XRExclusiveSocket>();

		_socket.selectEntered.AddListener(OnSelectEntered);
	}

	void OnSelectEntered(SelectEnterEventArgs args)
	{
		GameObject other = args.interactableObject.transform.gameObject;
		Destroy(other);
	}
}
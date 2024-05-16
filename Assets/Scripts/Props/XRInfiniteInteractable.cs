using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.XR.Interaction.Toolkit;

public class XRInfiniteInteractable : MonoBehaviour
{
	[SerializeField]
	XRBaseInteractable m_InteractablePrefab;

	XRBaseInteractor m_Socket;

	private void Awake()
	{
		m_Socket = GetComponent<XRBaseInteractor>();
		Assert.IsNotNull(m_InteractablePrefab);

		PlaceMag();
	}

	private void OnEnable()
	{
		m_Socket.selectExited.AddListener(OnSelectExited);
	}

	private void OnDisable()
	{
		m_Socket.selectExited.RemoveListener(OnSelectExited);
	}

	void OnSelectExited(SelectExitEventArgs selectExitEventArgs)
	{
		PlaceMag();
	}

	public void PlaceMag()
	{
		Transform socketTransform = m_Socket.transform;
		XRBaseInteractable interactable = Instantiate(m_InteractablePrefab, socketTransform.position, socketTransform.rotation);

        m_Socket.interactionManager.SelectEnter((IXRSelectInteractor)m_Socket, interactable);

        if (interactable.GetComponent<MagazineScr>())
		{
			interactable.GetComponent<MagazineScr>().b_exitPouch = false;
		}
		else return;
	}
}
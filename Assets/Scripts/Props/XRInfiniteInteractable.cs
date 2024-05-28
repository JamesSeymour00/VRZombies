using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.XR.Interaction.Toolkit;

public class XRInfiniteInteractable : MonoBehaviour
{
	[SerializeField]
	XRBaseInteractable m_InteractablePrefab;

	public bool b_canPlaceMag = true;

	XRBaseInteractor m_Socket;

	private void Awake()
	{
		m_Socket = GetComponent<XRBaseInteractor>();
		Assert.IsNotNull(m_InteractablePrefab);

        Transform socketTransform = m_Socket.transform;
        XRBaseInteractable interactable = Instantiate(m_InteractablePrefab, socketTransform.position, socketTransform.rotation);

        m_Socket.interactionManager.SelectEnter((IXRSelectInteractor)m_Socket, interactable);	
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

	private void PlaceMag()
	{
        if (b_canPlaceMag)
        {
            Debug.Log("PlaceMag");

            Transform socketTransform = m_Socket.transform;
            XRBaseInteractable interactable = Instantiate(m_InteractablePrefab, socketTransform.position, socketTransform.rotation);

            m_Socket.interactionManager.SelectEnter((IXRSelectInteractor)m_Socket, interactable);
        }       
    }
}
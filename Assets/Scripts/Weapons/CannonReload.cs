using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CannonReload : MonoBehaviour
{
	[SerializeField] ConfigurableJoint joint;

	public void OnGrab()
	{
		joint.zMotion = ConfigurableJointMotion.Limited;
	}

	public void OnRelease()
	{
		joint.zMotion = ConfigurableJointMotion.Locked;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TestCasing : MonoBehaviour
{
	public bool RotateForward;
	public bool RotateUp;
	public bool RotateRight;
	Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (RotateForward)
		{
			RotateForward = false;
			Debug.Log("Rotating");
			rb.AddTorque(Vector3.forward * 10000, ForceMode.Impulse);
		}

		if (RotateUp)
		{
			RotateUp = false;
			Debug.Log("Rotating");

		}

		if (RotateRight)
		{
			RotateRight = false;
			Debug.Log("Rotating");
			rb.AddTorque(Vector3.right * 10000, ForceMode.Impulse);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeDoor : MonoBehaviour
{
	private Vector3 startPos;
	[SerializeField] Transform endPos;
	[SerializeField] float doorSpeed;
	public bool pressed = false;

	Vector3 Velocity = new Vector3(0, 0, 0);

	private void Awake()
	{
		startPos = transform.position;
	}

	private void FixedUpdate()
	{
		if (pressed)
		{
			transform.position = Vector3.SmoothDamp(transform.position, endPos.position, ref Velocity, Time.deltaTime * doorSpeed);
		}
		else
		{
			transform.position = Vector3.SmoothDamp(transform.position, startPos, ref Velocity, Time.deltaTime * doorSpeed);
		}
	}

	public void StartRound()
	{
		pressed = true;
	}

	public void EndRound()
	{
		pressed = false;
	}
}
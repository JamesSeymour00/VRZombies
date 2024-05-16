using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLost : MonoBehaviour
{
	private Vector3 v3_startPos;

	private void Awake()
	{
		v3_startPos = transform.position;
	}

	private void Update()
	{
		if (transform.position.y < -2f)
		{
			transform.position = v3_startPos;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltScr : MonoBehaviour
{
	[SerializeField] Vector3 BeltOffset;
	private Transform t_cameraPos;

	private void Start()
	{
		t_cameraPos = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}

	private void Update()
	{
		this.transform.position = t_cameraPos.position + BeltOffset;
		this.transform.rotation = t_cameraPos.rotation;
	}
}
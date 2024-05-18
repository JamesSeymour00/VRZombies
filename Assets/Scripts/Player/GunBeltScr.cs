using UnityEngine;

public class CopyZRotation : MonoBehaviour
{
	private Transform t_cameraPos;
	[SerializeField] Vector3 BeltOffset;

	private void Start()
	{
		t_cameraPos = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}

	private void Update()
	{
		// Set the position with the offset
		this.transform.position = t_cameraPos.position + BeltOffset;

		// Extract the Z-axis rotation from the camera
		float yRotation = t_cameraPos.eulerAngles.y;

		// Apply the Z rotation to the object while ignoring the X and Y rotations
		transform.rotation = Quaternion.Euler(0, yRotation, 0);
	}
}
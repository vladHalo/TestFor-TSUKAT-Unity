using UnityEngine;
using static MoveCamera;
public class ScrollMove : MonoBehaviour
{
	///Рух камери по орбіті
	public Transform target;
	public Vector3 offset;
	public float sensitivity = 3; 
	public float limit = 80; 
	public float zoom = 40; 
	public float zoomMax = 800; 
	public float zoomMin = 25; 
	float X, Y;
	bool cheack=true;

	void Start()
	{
		limit = Mathf.Abs(limit);
		if (limit > 90) limit = 90;
		offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax) / 2);
	}

	void Update()
	{
		if (activateScrollMove)
		{
			if (cheack) 
			{
				transform.position = target.position + offset;
				cheack = false;
			}

			if (Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += zoom;
			else if (Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= zoom;
			offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));

			X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
			Y += Input.GetAxis("Mouse Y") * sensitivity;
			Y = Mathf.Clamp(Y, -limit, limit);
			transform.localEulerAngles = new Vector3(-Y, X, 0);
			transform.position = transform.localRotation * offset + target.position;
		}
	}
}
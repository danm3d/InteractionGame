using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public float rotationSpeed = 4f;
	private Vector3 rotationVector;
	public bool keyboardEnabled = true;
	private int one = 1;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");
		rotationVector = new Vector3(y, -x);
		if (keyboardEnabled)
		{
			transform.Rotate(rotationVector * rotationSpeed * Time.deltaTime, Space.Self);
		}
		else
		{
			float localX = transform.localEulerAngles.x;
			if (localX >= 35 || localX <= -35)
			{
				one = -one;
			}
			transform.Rotate(one * rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime, 0f);
		}
		transform.rotation = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
	}

	public void ToggleKeyboardInput(bool enable)
	{
		keyboardEnabled = enable;
	}
}


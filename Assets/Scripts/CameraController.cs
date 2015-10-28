using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{

	public float rotationSpeed = .5f;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		transform.eulerAngles += new Vector3(0f, rotationSpeed * Time.deltaTime);
	}
}

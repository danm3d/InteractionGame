using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
public class Demo : MonoBehaviour
{
	public int numberOfCubes;
	public float rotationSpeed;
	public float sphereRadius;
	public Transform cameraPivot = null;
	public GameObject cubePrefab = null;
	public GameObject spherePrefab;
	private Vector3 rotationVector;
	private Vector2 inputVector;
	private List<GameObject> cubes = null;
	private void SpawnCubes()
	{
		cubes = new List<GameObject>();
		Vector3 centerOfSphere = Vector3.zero;
		for (int i = 0; i < numberOfCubes; i++)
		{
			var cube = Instantiate(cubePrefab) as GameObject;
			cube.GetComponent<CubeBehaviour>().cubeMesh.transform.localPosition += new Vector3(0, 0, -sphereRadius);
			cube.transform.parent = transform;
			Vector3 placementPosition = cube.transform.position;

			Vector3 normal = (placementPosition - centerOfSphere).normalized;
			cube.transform.LookAt(Random.onUnitSphere * sphereRadius);
			cubes.Add(cube);
		}
	}

	// Use this for initialization
	private void Start()
	{
		var sphere = Instantiate(spherePrefab) as GameObject;
		SpawnCubes();
		sphere.transform.localScale *= sphereRadius;
		Camera.main.transform.localPosition = new Vector3(0, 0, -sphereRadius - 50f);
		rotationVector = new Vector3(0f, rotationSpeed, 0);
	}

	// Update is called once per frame
	private void Update()
	{
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");
		rotationVector = new Vector3(y, -x);
	}

	private void FixedUpdate()
	{
		cameraPivot.Rotate(rotationVector * rotationSpeed * Time.fixedDeltaTime, Space.Self);
	}
}
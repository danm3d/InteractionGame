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
	private IEnumerator SpawnCubes()
	{
		cubes = new List<GameObject>();
		Vector3 centerOfSphere = Vector3.zero;
		for (int i = 0; i < numberOfCubes; i++)
		{
			var cube = Instantiate(cubePrefab) as GameObject;
			cube.GetComponent<CubeBehaviour>().cubeMesh.transform.localPosition += new Vector3(0, 0, -sphereRadius);
			cube.GetComponent<CubeBehaviour>().Name = NameGenerator.GetRandomFirstName() + " " + NameGenerator.GetRandomLastName();

			cube.transform.parent = transform;
			Vector3 placementPosition = cube.transform.position;

			Vector3 normal = (placementPosition - centerOfSphere).normalized;
			cube.transform.LookAt(Random.onUnitSphere * sphereRadius);
			cubes.Add(cube);
			yield return new WaitForSeconds(0.2f);
		}
	}

	// Use this for initialization
	private void Start()
	{
		var sphere = Instantiate(spherePrefab) as GameObject;
		sphere.transform.localScale *= sphereRadius;
		Camera.main.transform.localPosition = new Vector3(0, 0, -sphereRadius - 50f);
		rotationVector = new Vector3(0f, rotationSpeed, 0);
		StartCoroutine(SpawnCubes());
	}
}
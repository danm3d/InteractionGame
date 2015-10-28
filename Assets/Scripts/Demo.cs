using UnityEngine;

public class Demo : MonoBehaviour
{
	public int numberOfCubes;
	public float rotationSpeed;
	public float sphereRadius;
	public Transform cameraPivot = null;
	public GameObject cubePrefab = null;
	public GameObject spherePrefab;
	private Vector3 randomRotation;
	private void SpawnCubes()
	{
		Vector3 centerOfSphere = Vector3.zero;
		for (int i = 0; i < numberOfCubes; i++)
		{
			var cube = Instantiate(cubePrefab) as GameObject;
			cube.transform.position = Random.onUnitSphere * sphereRadius;
			cube.transform.parent = transform;
			Vector3 placementPosition = cube.transform.position;

			Vector3 normal = (placementPosition - centerOfSphere).normalized;
			cube.transform.LookAt(centerOfSphere);// = Quaternion.Euler(normal);
		}
	}

	// Use this for initialization
	private void Start()
	{
		SpawnCubes();
		var sphere = Instantiate(spherePrefab) as GameObject;
		var scale = sphere.transform.localScale;
		sphere.transform.localScale = scale * sphereRadius;
		Camera.main.transform.localPosition = new Vector3(0, 0, -sphereRadius - 50f);
		randomRotation = new Vector3(0f, rotationSpeed, 0);
	}

	// Update is called once per frame
	private void Update()
	{
		cameraPivot.Rotate(randomRotation * Time.deltaTime);
	} 
}
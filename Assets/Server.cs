using UnityEngine;
using System.Collections;

public class Server : MonoBehaviour
{

	private WWW site;
	[SerializeField]
	string serverUrl = "http://jsonplaceholder.typicode.com";
	[SerializeField]
	string directory = "/posts/";

	[SerializeField] GameObject container, textObject;
	// Use this for initialization
	void Start ()
	{
		site = new WWW (serverUrl + directory);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

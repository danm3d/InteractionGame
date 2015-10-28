using UnityEngine;
using System.Collections;

public class CubeBehaviour : MonoBehaviour
{
	public TypogenicText nameText, scoreText;
	// Use this for initialization
	void Start()
	{
		nameText.Text = "Namey McNamington";
		int score = Random.Range(1, 100);
		float scale = 1f + ((float)score / 80);
		transform.localScale = new Vector3(scale, scale, 1);
		scoreText.Text = score.ToString();
	}

	// Update is called once per frame
	void Update()
	{

	}
}

using UnityEngine;
using System.Collections;

public class CubeBehaviour : MonoBehaviour
{
	public TypogenicText nameText, scoreText;
	public MeshRenderer cubeMesh;
	private int mScore { get; set; }
	public float rotationSpeed = 1f;
	private Vector3 rotationVector;
	private int one = 1;

	void Start()
	{
		mScore = Random.Range(1, 200);
		float scale = 1f + ((float)mScore / 80);
		transform.localScale = new Vector3(scale, scale, 1);
		nameText.Text = NameGenerator.GetRandomFirstName() + " " + NameGenerator.GetRandomLastName();
		scoreText.Text = mScore.ToString();
		cubeMesh.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
		rotationSpeed = Random.Range(1f, 2f);
		rotationVector = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
		StartCoroutine(MoveAroundRandomly());
	}

	private IEnumerator MoveAroundRandomly()
	{
		for (;;)
		{
			if (Random.Range(0, 100) > 50)
			{
				mScore += Random.Range(1, 11);
				float scale = 1f + ((float)mScore / 50);
				iTween.ScaleTo(gameObject, iTween.Hash("time", .8f, "easeType", iTween.EaseType.easeInOutCubic, "scale", new Vector3(scale, scale, 1)));
				scoreText.Text = mScore.ToString();
			}
			yield return new WaitForSeconds(Random.Range(3f, 9f));
		}
	}

	void Update()
	{
		float localX = transform.localEulerAngles.x;
		if (localX >= 35 || localX <= -35)
		{
			one = -one;
		}
		transform.Rotate(one * rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime, 0f);
		transform.rotation = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);

	}
}

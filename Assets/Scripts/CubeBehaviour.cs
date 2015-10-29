using UnityEngine;
using System.Collections;

public class CubeBehaviour : MonoBehaviour
{
	public TypogenicText nameText, scoreText;
	public MeshRenderer cubeMesh;
	private int mScore { get; set; }

	private Vector3 rotationVector;
	void Start()
	{
		mScore = Random.Range(1, 200);
		float scale = 1f + ((float)mScore / 80);
		transform.localScale = new Vector3(scale, scale, 1);
		scoreText.Text = mScore.ToString();
		cubeMesh.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

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
				iTween.ScaleTo(gameObject, iTween.Hash("time", .8f, "easeType", iTween.EaseType.easeInOutSine, "scale", new Vector3(scale, scale, 1)));
				scoreText.Text = mScore.ToString();
			}
			yield return new WaitForSeconds(Random.Range(3f, 9f));
		}
	}

	void Update()
	{
		if (Mathf.Abs(transform.localEulerAngles.x) >= 175)
		{
			rotationVector.Set(-rotationVector.x, rotationVector.y, 0);
		}

		transform.Rotate(rotationVector * Time.deltaTime);

	}
}

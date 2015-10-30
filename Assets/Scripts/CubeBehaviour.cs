using UnityEngine;
using System.Collections;

public class CubeBehaviour : MonoBehaviour
{
	public TypogenicText nameText, scoreText;
	public MeshRenderer cubeMesh;
	private int mScore;

	public int Score
	{
		get { return mScore; }
		set
		{
			mScore = value;
			scoreText.Text = mScore.ToString();
		}
	}
	private string mName;

	public string Name
	{
		get { return mName; }
		set
		{
			mName = value;
			nameText.Text = mName;
		}
	}


	public float rotationSpeed = 1f;
	private Vector3 rotationVector;
	private int one = 1;

	void Start()
	{
		Score = Random.Range(1, 200);
		float scale = 1f + ((float)mScore / 80);
		transform.localScale = new Vector3(scale, scale, 1);
		cubeMesh.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
		rotationSpeed = Random.Range(1f, 2f);
		rotationVector = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
		StartCoroutine(MoveAroundRandomly());
	}

	private IEnumerator MoveAroundRandomly()
	{
		for (;;)
		{
			if (Random.Range(0, 10) == 10)
			{
				Score += Random.Range(1, 11);
				float scale = 1f + ((float)Score / 50);
				iTween.ScaleTo(gameObject, iTween.Hash("time", .8f, "easeType", iTween.EaseType.easeInOutCubic, "scale", new Vector3(scale, scale, 1)));
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

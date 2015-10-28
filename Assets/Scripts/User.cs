using UnityEngine;
using System.Collections;
using System;

public class User : MonoBehaviour
{
	public GameObject Cube;

	[SerializeField]
	private string mName;
	[SerializeField]
	private int mScore;

	public delegate void ScoreUpdatedAction();

	public static event ScoreUpdatedAction OnScoreUpdated;

	public string Name
	{
		get { return mName; }
		set { mName = value; }
	}

	public int Score
	{
		get { return mScore; }
		set { mScore = value; }
	}
	void Start()
	{
		Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
	}

	public void AddPoints(int points)
	{
		Score += points;
	}
	private void UpdateScore()
	{
		//TODO: Update Data
		//Data from serversi
	}


}
using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
	[SerializeField]
	private string SceneToLoad = "Visualiser";
	private Texture2D fadeTex;

	void Start()
	{
		fadeTex = new Texture2D(1, 1);
		fadeTex.SetPixel(0, 0, Color.black);
		fadeTex.Apply();
	}
	public void BeginFadeOut()
	{
		iTween.CameraFadeAdd(fadeTex, 10);
		iTween.CameraFadeTo(iTween.Hash("oncompletetarget", gameObject, "oncomplete", "LoadVisScene", "amount", 1f, "time", 3f));
	}
	public void LoadVisScene()
	{
		print("loadlevel");
		Application.LoadLevel(SceneToLoad);
	}
}

using UnityEngine;
using System.Collections;
using ZXing;
using ZXing.QrCode;
using System.Threading;
using ZXing.Common;
using System;

public class QRScanner : MonoBehaviour
{
	WebCamTexture camTexture;
	Thread qrThread;
	Color32[] c;
	sbyte[] d;
	int x, y, z;
	int W, H, WxH;
	void Start ()
	{
		WebCamDevice[] devices = WebCamTexture.devices;
		if (devices.Length > 0) {
			foreach (var device in devices) {
				Debug.Log (device.name);
			}
			camTexture = new WebCamTexture();
			OnEnable ();
			qrThread = new Thread(DecodeQR);
			qrThread.Start();
		} else {
			Debug.LogWarning ("No Camera Devices!");
		}


	}

	void OnEnable ()
	{
		if (camTexture != null) {
			camTexture.requestedWidth=1024;
			camTexture.requestedHeight=768;
			W = camTexture.requestedWidth;
			H = camTexture.requestedHeight;
			WxH = W * H;
			camTexture.Play ();
		}
	}
	
	void OnDisable ()
	{
		if (camTexture != null) {
			camTexture.Pause ();
		}
	}
	
	void OnDestroy ()
	{
		qrThread.Abort();
		camTexture.Stop ();
	}
	
	void Update ()
	{
		c = camTexture.GetPixels32 ();
	}

	void OnGUI ()
	{
		GUI.DrawTexture (new Rect (10, 10, H, W), camTexture);
	}

	void DecodeQR ()
	{
		while (true) {
			try {
				QRCodeReader reader = new QRCodeReader();
				LuminanceSource source = new Color32LuminanceSource(c,W,H);
				source.invert();
				var binarizer = new HybridBinarizer(source);
				var binBitmap = new BinaryBitmap(binarizer);
				Debug.Log (reader.decode(binBitmap).Text);
			} catch(Exception ex){
				Debug.LogWarning(ex.Message);
				continue;
			}
			Thread.Sleep(100);
		}
	}
}

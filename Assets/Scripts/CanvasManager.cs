using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour {

	public Texture2D fadeTexture;
public Canvas canvasView1;
	public Canvas canvasView2;
	private bool bFadeEnabled = false;

	[Range(0.1f,1f)]
	public float fadespeed;
	public int drawDepth = -1000;

	private float alpha = 1f;
	private float fadeDir = -1f;

	// Use this for initialization
	void Start () {
		// canvasView1.enabled = true;
		// canvasView2.enabled = false;
		canvasView1.gameObject.SetActive(true);
		canvasView2.gameObject.SetActive(false);
	}

	void OnGUI() {
		if (bFadeEnabled == true)
			fadeTransition ();
	}

	public void fadeTransition() {
		alpha += fadeDir * fadespeed * Time.deltaTime;
		alpha = Mathf.Clamp01(alpha);

		Color newColor = GUI.color; 
		newColor.a = alpha;

		GUI.color = newColor;
		GUI.depth = drawDepth;

		GUI.DrawTexture( new Rect(0,0, Screen.width, Screen.height), fadeTexture);
	}

	public void onGoToView2ButtonClicked() {
		// canvasView1.enabled = !canvasView1.enabled;
		// canvasView2.enabled = !canvasView2.enabled;
		canvasView1.gameObject.SetActive(!canvasView1.gameObject.active);
		canvasView2.gameObject.SetActive(!canvasView2.gameObject.active);

		bFadeEnabled = true;
	}
}
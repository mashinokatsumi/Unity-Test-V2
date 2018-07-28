using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CubeGenerator : MonoBehaviour {

	[SerializeField]
	private GameObject cubeObject;
	[SerializeField]
	private Text txtUTC;
	[SerializeField (), Range (1f, 3f)]
	private float spawnTime = 2f;
	[SerializeField]
	private GameObject cubeContainerObject;
	private int distance = 0;
	private Stopwatch timer;
	private bool bStart;

	//private List<GameObject> localGameObjectList;

	void Start () {
		//localGameObjectList = new List<GameObject> ();
		//syncEvenSecond();
		timer = Stopwatch.StartNew();
		bStart = false;
	}

	void FixedUpdate() {
		txtUTC.text = "UTC Time: " + DateTime.UtcNow.ToString("HH':'mm':'ss");
		if (bStart == false) {
			if (DateTime.UtcNow.Second % 2 == 0) {
				if (timer.ElapsedMilliseconds > 2000 - DateTime.UtcNow.Millisecond) {
					bStart = true;
					InvokeRepeating ("SpawnCube", spawnTime, spawnTime);
				}
			} else {
				if (timer.ElapsedMilliseconds > 1000 - DateTime.UtcNow.Millisecond) {
					bStart = true;
					InvokeRepeating ("SpawnCube", spawnTime, spawnTime);
				}
			}
		}
	}
	/*
	IEnumerator syncEvenSecond() {
		int millisecond_remain = c;
		if (DateTime.UtcNow.Second % 2 == 0) {
			yield return new WaitForSeconds ((float)(millisecond_remain / 1000 + 1.0f));
			InvokeRepeating ("SpawnCube", spawnTime, spawnTime);
		} else {
			yield return new WaitForSeconds((float)(millisecond_remain / 1000));
			InvokeRepeating ("SpawnCube", spawnTime, spawnTime);
		}
	}
	*/
	void SpawnCube()
	{
		if (distance <= 10)
			distance ++;

		var instantiatedObject = GameObject.Instantiate(cubeObject, cubeObject.transform.position + (cubeObject.transform.right * distance), cubeObject.transform.rotation);
		instantiatedObject.transform.parent = cubeContainerObject.transform;
		instantiatedObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

		if (cubeContainerObject.transform.childCount > 10) {
			Destroy (cubeContainerObject.transform.GetChild (0).gameObject);
			for (int i = 0; i < cubeContainerObject.transform.childCount; i++) {
				cubeContainerObject.transform.GetChild (i).Translate (-cubeObject.transform.right * 1);
			}
		}
		/*localGameObjectList.Add (instantiatedObject);
		if (localGameObjectList.Count > 10) {
			localGameObjectList.RemoveAt (0);
		}*/
	}
}
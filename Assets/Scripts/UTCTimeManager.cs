using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UTCTimeManager : MonoBehaviour {

	[SerializeField]
	private Text txtUTC;

	void Update () {
		txtUTC.text = "UTC Time: " + DateTime.UtcNow.ToString("HH':'mm':'ss");
	}
}
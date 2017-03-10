using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCanvasUI : MonoBehaviour {

	public bool showUI = true;
	public GameObject ui;

	// Use this for initialization
	void Start () {
		Invoke("HideUI", 4f);
	}
	
	// Update is called once per frame
	void Update () {
		if (!showUI) {
			ui.SetActive (false);
		}
	}

	void HideUI() {
		showUI = false;
	}
}

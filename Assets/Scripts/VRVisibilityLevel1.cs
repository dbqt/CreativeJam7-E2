using UnityEngine;
using System.Collections;

public class VRVisibilityLevel1 : MonoBehaviour {
	public GameObject hint;
	// Use this for initialization
	void Start () {

		var all = hint.GetComponentsInChildren<MeshRenderer> ();
		foreach (var elem in all) {
			elem.enabled = GameManager.instance.isVRMode;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

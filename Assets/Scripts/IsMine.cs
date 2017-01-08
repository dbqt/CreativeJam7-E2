using UnityEngine;
using System.Collections;

public class IsMine : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GameManager.instance.isPlayerOne)
			this.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

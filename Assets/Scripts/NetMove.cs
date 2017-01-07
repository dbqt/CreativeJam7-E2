using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (!this.gameObject.GetComponent<NetworkIdentity>().isLocalPlayer) return;
		
		var x = Input.GetAxis("Horizontal")*0.1f;
		var z = Input.GetAxis("Vertical")*0.1f;

		transform.Translate(x, 0, z);
	}
}

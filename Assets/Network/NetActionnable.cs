using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetActionnable : NetworkBehaviour {

	[SyncVar]
	bool effectState;

	// Use this for initialization
	void Start () {
		effectState = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		//if (this.gameObject.GetComponent<NetworkIdentity> ().isServer) {
			Debug.Log ("action trigger!" + effectState);
			effectState = !effectState;
		//} else {
			
		//}

	}
}

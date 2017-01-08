using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetActionnable : NetworkBehaviour {

	[SyncVar]
	public bool effectState;

	// Use this for initialization
	void Start () {
		effectState = false;
	}

	public virtual void ToggleState(){
		effectState = !effectState;
	}
}

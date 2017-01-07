using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetMove : MonoBehaviour {
	public GameObject ActionZone;

	// Use this for initialization
	void Start () {
	
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {

		if (!this.gameObject.GetComponent<NetworkIdentity>().isLocalPlayer) return;
		
		var x = Input.GetAxis("Horizontal")*0.1f;
		var z = Input.GetAxis("Vertical")*0.1f;

		transform.Translate(x, 0, z);

		if (Input.GetButton ("Fire1")) {
			ActivateEffect ();
		}
	}

	/// <summary>
	/// Activates the effect.
	/// </summary>
	private void ActivateEffect (){
		Debug.Log ("effect~"+ this.gameObject.GetComponent<NetworkIdentity>().isServer);
	}
}

using UnityEngine;
using System.Collections;

public class KillingFloor : MonoBehaviour {

	void OnCollisionEnter(Collision col) {
		if(col.gameObject.name == "Player"){
			GameManager.instance.ResetPlayers ();
		}

	}
}

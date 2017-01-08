using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		this.gameObject.GetComponent<Animator> ().SetBool ("isDoorOpen", true);
	}

	void OnTriggerExit(Collider other) {
		this.gameObject.GetComponent<Animator> ().SetBool ("isDoorOpen", false);
	}
}

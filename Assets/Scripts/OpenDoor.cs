using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {
    AudioSource soundS;
    public AudioClip open;

    void Start()
    {
        this.soundS = (gameObject.AddComponent<AudioSource>() as AudioSource);
        soundS.clip = open;
    }

	void OnTriggerEnter(Collider other) {
        soundS.Play();
		this.gameObject.GetComponent<Animator> ().SetBool ("isDoorOpen", true);
	}

	void OnTriggerExit(Collider other) {
		this.gameObject.GetComponent<Animator> ().SetBool ("isDoorOpen", false);
	}
}

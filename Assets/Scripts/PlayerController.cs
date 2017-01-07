using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	public GameObject Head;

	public ParticleSystem Fire;

	public float moveSpeed = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!this.gameObject.GetComponent<NetworkIdentity>().isLocalPlayer) return;

		var move = new Vector3 (Input.GetAxis ("Horizontal"), 0f, Input.GetAxis ("Vertical"));
		move *= moveSpeed;

		var rotationBody = new Vector3 (0f, Input.GetAxis ("HorizontalRight"), 0f);
		var rotationHead = new Vector3 (Input.GetAxis ("VerticalRight"), 0f, 0f);

		if (Input.GetButtonDown ("Fire1")) {
			Fire.Play ();                                        
		} 

		if (Input.GetButtonUp("Fire1")) {
			Fire.Stop ();
		}

		ApplyTransformations (move, rotationBody, rotationHead);
	}

	private void ApplyTransformations(Vector3 movement, Vector3 rotationBody, Vector3 rotationHead) {
		this.gameObject.transform.Rotate (rotationBody);

		Head.transform.Rotate (rotationHead);

		Head.transform.rotation = ClampRotationAroundXAxis (Head.transform.rotation, -15f, 15f);
		var rot = Head.transform.localEulerAngles;
		rot.y = 0f;
		rot.z = 0f;
		Head.transform.localEulerAngles = rot;

		this.gameObject.transform.Translate (movement);

	}

	private Quaternion ClampRotationAroundXAxis(Quaternion q, float min, float max)
	{
		q.x /= q.w;
		q.y /= q.w;
		q.z /= q.w;
		q.w = 1.0f;

		float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);

		angleX = Mathf.Clamp (angleX, min, max);

		q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);

		return q;
	}
}

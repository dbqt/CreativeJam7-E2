using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToMenu : MonoBehaviour {

    public float waitDuration = 3f;

    private bool unlocked = false;

	// Use this for initialization
	void Start () {
        unlocked = false;
		//Invoke("UnlockEnd", waitDuration);
	}
	
	// Update is called once per frame
	void Update () {
		//if(unlocked) {
            if(Input.GetButtonUp("Submit")) {
                GameManager.instance.LoadNextLevel();
            }
        //}
	}

    void UnlockEnd(){
        unlocked = true;
    }
}

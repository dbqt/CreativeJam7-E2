using UnityEngine;
using System.Collections;

public class EndGameScript : MonoBehaviour {

    bool once = false;
    // Use this for initialization
    void Start() {
        once = false;
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter(Collider other) {

        if(!once){
            once = true;
            GameManager.instance.LoadNextLevel();   
        }
    }

    public void returnToMenu()
    {
        //GameManager.instance.ReturnToMenu();
    }
}

using UnityEngine;
using System.Collections;

public class EndGameScript : MonoBehaviour {


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter(Collider other) {
        GameManager.instance.LoadNextLevel();
    }

    public void returnToMenu()
    {
        //GameManager.instance.ReturnToMenu();
    }
}

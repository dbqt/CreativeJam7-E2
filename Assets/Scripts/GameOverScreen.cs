﻿using UnityEngine;

public class GameOverScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RestartLevel()
    {
        GameManager.instance.RedoLevel();
    }

    public void ReturnToMenu()
    {
        GameManager.instance.ReturnToMenu();
    }
}

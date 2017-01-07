using UnityEngine;
using UnityEngine.SceneManagement;

public class LoreAnimationScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("SHOW LORE ANIMATION");
        GameManager.instance.LoadNextLevel();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

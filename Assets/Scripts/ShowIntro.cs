using UnityEngine;
using UnityEditor.SceneManagement;

public class ShowIntro : MonoBehaviour {
    public GameObject scene1, scene2, scene3;
    public Animator anim;
    int state = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void showNext() {
        Debug.Log("Showing Next");
        switch (state)
        {
            case 0:
                anim.SetTrigger("showScene2");
                break;
            case 1:
                anim.SetTrigger("showScene3");
                break;
            case 2:
                GameManager.instance.LoadNextLevel();
                break;
        }
        state++;
    }
}

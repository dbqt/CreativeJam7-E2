using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowIntro : MonoBehaviour {
    public GameObject scene1, scene2, scene3;
    public Animator anim;
    int state = 0;
    public AudioSource soundS;
    public AudioClip pageFlip;

    // Use this for initialization
    void Start() {
        this.soundS = (gameObject.AddComponent<AudioSource>() as AudioSource);
        soundS.clip = pageFlip;
    }

    void playPageFlip()
    {
        soundS.Play();
    }

	// Update is called once per frame
	void LateUpdate () {
	   if(Input.GetButtonUp("Submit")) {
            showNext();
       }
	}

    public void showNext() {
        Debug.Log("Showing Next");
        playPageFlip();
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

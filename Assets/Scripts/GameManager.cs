using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    static public GameManager instance = null;
    public string[] Levels;

    public int CurrentLevel;

	public Canvas menuCanvas;
    public Text target;

	public GameObject playerInstance, vrPlayer;

	public bool isVRMode = false;
    public AudioClip[] audiosounds;
    public AudioSource audioSource;

    private AsyncOperation currentOperation;
	private bool newOperation = false;


    // Use this for initialization
    void Start() {
        // singleton logic
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        playerInstance.SetActive(false);
        vrPlayer.SetActive(false);

        this.audioSource = (gameObject.AddComponent<AudioSource>() as AudioSource);
        playMusic(1);
    }

    public void playMusic(int musicNb)
    {
        Debug.Log("PLAYING MUSIC " + musicNb);
        audioSource.Stop();
        audioSource.clip = audiosounds[musicNb];
        audioSource.Play();
    }

	void Update(){
		if (newOperation && currentOperation.isDone) {
			ResetPlayers ();
			newOperation = false;
		}

	}

    public void StartNewGame()
    {
		CurrentLevel = 0;
    }
    
    public void ReturnToMenu()
    {
        GameManager.instance.playMusic(0);
        CurrentLevel = 0;
        SceneManager.LoadScene(Levels[CurrentLevel]);
    }

    public void ShowGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    
    public void LoadNextLevel()
    {
        if (Levels.Length < 0) return;

		if (isVRMode) {
			playerInstance.SetActive (false);
			vrPlayer.SetActive (true);
		} else {
			playerInstance.SetActive (true);
			vrPlayer.SetActive (false);
		}

        // Level 0 is menu
        CurrentLevel++;
        Debug.Log("HEADING TO NEXT LEVEL " + CurrentLevel);
        CurrentLevel = CurrentLevel%Levels.Length;
        if(CurrentLevel == 2)
        {
            playMusic(0);
        }
        if(CurrentLevel == 0)
        {
            playerInstance.SetActive(false);
            vrPlayer.SetActive(false);
            playMusic(1);
        }
		currentOperation = SceneManager.LoadSceneAsync(Levels[CurrentLevel]);
		newOperation = true;

    }

	public void HideCanvas() {
		menuCanvas.enabled = false;
	}

    public void ShowTarget()
    {
        target.enabled = true;
    }

    public void RedoLevel()
    {
        SceneManager.LoadScene(Levels[CurrentLevel]);
    }

	public void ResetPlayers (){
		if (isVRMode) {
			var o = GameObject.Find ("VRSPOT");
			vrPlayer.transform.position = o.transform.position;
			vrPlayer.transform.rotation = o.transform.rotation;
		} else {
			playerInstance.transform.position = Vector3.zero;
			playerInstance.transform.rotation = Quaternion.identity;
		}
	}

	public void SyncLevel(){
	
	}
		
}

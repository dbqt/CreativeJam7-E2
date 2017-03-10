using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

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

    private DatabaseReference reference;

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
        audioSource.loop = true;

        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://trials-of-fire-and-ice.firebaseio.com/");
        // Get the root reference location of the database.
        reference= FirebaseDatabase.DefaultInstance.RootReference;
  
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

        SyncVR();

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

        // Level 0 is menu
        CurrentLevel++;
        Debug.Log("HEADING TO NEXT LEVEL " + CurrentLevel);
        CurrentLevel = CurrentLevel % Levels.Length;
        if (CurrentLevel == 2)
        {
            playMusic(0);
        }
        if (CurrentLevel == 1 || CurrentLevel == 0)
        {
            playerInstance.SetActive(false);
            vrPlayer.SetActive(false);
            if (CurrentLevel == 0)
            {
                playMusic(1);
            }
        } else
        {
            if (isVRMode)
            {
                playerInstance.SetActive(false);
                vrPlayer.SetActive(true);
            }
            else
            {
                playerInstance.SetActive(true);
                vrPlayer.SetActive(false);
            }
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
			/*var o = GameObject.Find ("VRSPOT :evel");
			vrPlayer.transform.position = o.transform.position;
			vrPlayer.transform.rotation = o.transform.rotation;*/
		} else {
            var o = GameObject.Find ("PLAYERSTART");
            if(o == null) return;
			playerInstance.transform.position = o.transform.position;
			playerInstance.transform.rotation = o.transform.rotation;
		}
	}

	public void SyncVR(){
        if(isVRMode){
            FirebaseDatabase.DefaultInstance
      .GetReference("DataVR")
      .GetValueAsync().ContinueWith(task => {
        if (task.IsFaulted) {
          // Handle the error...
          Debug.Log("i didnt work");
        }
        else if (task.IsCompleted) {
          DataSnapshot snapshot = task.Result;
          // Do something with snapshot...
          string json = snapshot.GetRawJsonValue();
          DataVR data = JsonUtility.FromJson<DataVR>(json);
          Debug.Log("x: "+data.playerPositionX);
        }
      });
        }
        else{
        	DataVR data = new DataVR(){
                playerPositionX = playerInstance.transform.position.x,
                playerPositionY = playerInstance.transform.position.y,
                playerPositionZ = playerInstance.transform.position.z,
                isVRSpot1 = true,
                isBalanced = false,
                torch1 = false,
                torch2 = false,
                torch3 = false,
                torch4 = false,
                torch5 = false
            };
            string json = JsonUtility.ToJson(data);

            reference.Child("DataVR").SetRawJsonValueAsync(json);
        }
	}

    public void PlaceVRSpot1(){

    }

    public void PlaceVRSpot2(){

    }
		
}

public class DataVR {
    public float playerPositionX, playerPositionY, playerPositionZ;
    public bool isVRSpot1;
    public bool isBalanced;
    public bool torch1, torch2, torch3, torch4, torch5;

    public DataVR() { }
}

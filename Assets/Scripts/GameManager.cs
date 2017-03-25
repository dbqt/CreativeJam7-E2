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

	public GameObject playerInstance, vrPlayer, vrPlayerGhost;

	public bool isVRMode = false;
    public AudioClip[] audiosounds;
    public AudioSource audioSource;

    private AsyncOperation currentOperation;
	private bool newOperation = false;

    private DatabaseReference reference;
    
    //data to sync
    public bool t1, t2, t3, t4, t5, balanced, playerIsVRSpot1;
    public float syncIntervalTime = 0.5f;

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
        vrPlayerGhost.SetActive(false);
        Reset();

        this.audioSource = (gameObject.AddComponent<AudioSource>() as AudioSource);
        playMusic(1);
        audioSource.loop = true;

        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://trials-of-fire-and-ice.firebaseio.com/");
        // Get the root reference location of the database.
        reference= FirebaseDatabase.DefaultInstance.RootReference;

        Sync();
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
    public void Reset(){
        t1 = false;
        t2 = false;
        t3 = false;
        t4 = false;
        t5 = false;
        balanced = false;
        playerIsVRSpot1 = true;
    }

    public void StartNewGame()
    {
		CurrentLevel = 0;
       Reset();

       if(isVRMode){
        CurrentLevel = 1;
        LoadNextLevel();
       }
    }
    
    public void ReturnToMenu()
    {
        GameManager.instance.playMusic(0);
        CurrentLevel = 0;
        Reset();
        SceneManager.LoadScene(Levels[CurrentLevel]);
    }

    public void ShowGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void LoadNextLevel()
    {
        if (Levels.Length < 0) return;

        Reset();

        if(isVRMode){
        CurrentLevel = 1;
       }

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
            vrPlayerGhost.SetActive(false);
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
                vrPlayerGhost.SetActive(true);
            }
            else
            {
                playerInstance.SetActive(true);
                vrPlayer.SetActive(false);
                vrPlayerGhost.SetActive(false);
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
        Reset();
    }

	public void ResetPlayers (){
        Reset();
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
        if(isVRMode) {
            FirebaseDatabase.DefaultInstance.GetReference("DataVR").GetValueAsync().ContinueWith(task => 
            {
                if (task.IsFaulted) {
                  // Handle the error...
                  Debug.Log("i didnt work");
                }
                else if (task.IsCompleted) {
                    DataSnapshot snapshot = task.Result;
                    // Do something with snapshot...
                    string json = snapshot.GetRawJsonValue();
                    DataVR data = JsonUtility.FromJson<DataVR>(json);
                    Debug.Log("synced");
                    
                    // sync level data
                    playerIsVRSpot1 = data.isVRSpot1;
                    balanced = data.isBalanced;
                    t1 = data.torch1;
                    t2 = data.torch2;
                    t3 = data.torch3;
                    t4 = data.torch4;
                    t5 = data.torch5;

                    // place self at vr spot
                    VRManager vrManager = FindObjectOfType(typeof(VRManager)) as VRManager;
                    if(vrManager != null){
                        Debug.Log("found");
                        vrPlayer.transform.position = (playerIsVRSpot1) ? vrManager.vrspot1.position : vrManager.vrspot2.position;
                        vrPlayer.transform.rotation = (playerIsVRSpot1) ? vrManager.vrspot1.rotation : vrManager.vrspot2.rotation;
                    }
                    // place player ghost
                    vrPlayerGhost.transform.position = new Vector3(data.playerPositionX, data.playerPositionY, data.playerPositionZ);
                    
                }
            });
        }
        // send to server
        else{
        	DataVR data = new DataVR(){
                playerPositionX = playerInstance.transform.position.x,
                playerPositionY = playerInstance.transform.position.y,
                playerPositionZ = playerInstance.transform.position.z,
                isVRSpot1 = playerIsVRSpot1,
                isBalanced = balanced,
                torch1 = t1,
                torch2 = t2,
                torch3 = t3,
                torch4 = t4,
                torch5 = t5
            };
            string json = JsonUtility.ToJson(data);

            reference.Child("DataVR").SetRawJsonValueAsync(json);
        }

        Invoke("Sync", syncIntervalTime);
	}

    public void SetBalanceData(bool balanced){
        this.balanced = balanced;
    }

    public void SetTorchesData(bool t1, bool t2, bool t3, bool t4, bool t5){
        this.t1 = t1;
        this.t2 = t2;
        this.t3 = t3;
        this.t4 = t4;
        this.t5 = t5;
    }

    public void PlaceVRSpot1(){
        playerIsVRSpot1 = true;
    }

    public void PlaceVRSpot2(){
        playerIsVRSpot1 = false;
    }
		
}

public class DataVR {
    public float playerPositionX, playerPositionY, playerPositionZ;
    public bool isVRSpot1;
    public bool isBalanced;
    public bool torch1, torch2, torch3, torch4, torch5;

    public DataVR() { }
}

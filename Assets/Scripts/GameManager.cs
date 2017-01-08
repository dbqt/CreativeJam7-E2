using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    static public GameManager instance = null;
    public string[] Levels;
    public int CurrentLevel;

	public NetworkCalls networkCalls;
	public Canvas menuCanvas;
    public Text target;
	public GameObject player1Prefab, playerVRPrefab;

	private bool hasCreated = false;
	private bool isWaiting = false;
	private bool isPlaying = false;

	private bool player1 = false, player2 = false;
	private bool amServer = false;

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
    }

    // Update is called once per frame
    void Update() {
		// created match, now waiting for second player
		if (isWaiting && hasCreated && !isPlaying) {
			Debug.Log ("waiting...");
		}

		// player joined, we can load the next thing
		if (!isWaiting && hasCreated && !isPlaying) {
			Debug.Log ("done waiting!");
			isPlaying = true;
			// Level 0 is menu
			//LoadNextLevel();
		}
    }

	public void OnPlayerConnectedToServer(bool isServer){
		Debug.Log("Player connected!");
		isWaiting = false;
		amServer = isServer;
	}

    public void StartNewGame()
    {
		CurrentLevel = 0;
		CreateGameAndWait ();
    }

	//[Command]
    public void LoadNextLevel()
    {
        if (Levels.Length < 0) return;

        // Level 0 is menu
        CurrentLevel++;
        Debug.Log("HEADING TO NEXT LEVEL " + CurrentLevel);
        CurrentLevel = CurrentLevel%Levels.Length;
        SceneManager.LoadScene(Levels[CurrentLevel]);

		if (amServer) {
			Instantiate (player1Prefab, Vector3.zero, Quaternion.identity);
		} else {
			Instantiate (playerVRPrefab, Vector3.zero, Quaternion.identity);
		}
    }

	public void HideCanvas() {
		menuCanvas.enabled = false;
	}

    public void ShowTarget()
    {
        target.enabled = true;
    }

	private void CreateGameAndWait (){
		networkCalls.StartMatch ();
		HideCanvas ();
        ShowTarget();
        hasCreated = true;
		isWaiting = true;
	}
		
}

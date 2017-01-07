using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameManager instance = null;
    public string[] Levels;
    public int CurrentLevel;

	public NetworkCalls networkCalls;
	public Canvas menuCanvas;

	private bool hasCreated = false;
	private bool isWaiting = false;

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
		if (isWaiting && hasCreated) {
			Debug.Log ("waiting...");
		}

		// player joined, we can load the next thing
		if (!isWaiting && hasCreated) {
			Debug.Log ("done waiting!");
			// Level 0 is menu
			LoadNextLevel();
		}
    }

	public void OnPlayerConnected(){
		Debug.Log("Player connected!");
		isWaiting = false;
	}

    public void StartNewGame()
    {
		CurrentLevel = 0;
		CreateGameAndWait ();
    }

    public void LoadNextLevel()
    {
        if (Levels.Length < 0) return;

        // Level 0 is menu
        CurrentLevel++;
        Debug.Log("HEADING TO NEXT LEVEL " + CurrentLevel);
        CurrentLevel = CurrentLevel%Levels.Length;
        SceneManager.LoadScene(Levels[CurrentLevel]);
    }

	public void HideCanvas() {
		menuCanvas.enabled = false;
	}

	private void CreateGameAndWait (){
		networkCalls.StartMatch ();
		HideCanvas ();
		hasCreated = true;
		isWaiting = true;
	}
		
}

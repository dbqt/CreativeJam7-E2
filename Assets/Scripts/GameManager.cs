using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    static public GameManager instance = null;
    public string[] Levels;
	public string[] LevelsVR;

    public int CurrentLevel;

	public Canvas menuCanvas;
    public Text target;
	public GameObject player1Prefab, playerVRPrefab;


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

    }
		

    public void StartNewGame()
    {
		CurrentLevel = 0;
    }
    
    public void ReturnToMenu()
    {
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
        CurrentLevel = CurrentLevel%Levels.Length;
        SceneManager.LoadScene(Levels[CurrentLevel]);
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

	public void LoadVRMode(){
	
	}

	public void LoadNextVRLevel(){
	
		if (Levels.Length < 0) return;

		// Level 0 is menu
		Debug.Log("HEADING TO NEXT LEVEL " + CurrentLevel);
		CurrentLevel = CurrentLevel%Levels.Length;
		SceneManager.LoadScene(Levels[CurrentLevel]);
	}
		
}

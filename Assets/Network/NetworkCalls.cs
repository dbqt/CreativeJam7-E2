using UnityEngine.Networking;
using UnityEngine.Networking.Match;

using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


public class NetworkCalls : NetworkBehaviour {

	NetworkMatch matchMaker;

	public Canvas canvas;

	private MatchInfoSnapshot currentMatch;

	// Use this for initialization
	void Start () {
		NetworkManager.singleton.StartMatchMaker ();
		matchMaker = NetworkManager.singleton.matchMaker;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartMatch(){
		matchMaker.CreateMatch ("room", 2, true, "", "", "", 0, 1, NetworkManager.singleton.OnMatchCreate);
		canvas.enabled = false;
	}

	public void JoinMatch(){
		matchMaker.ListMatches (0, 2, "", false, 0, 1, JoinActualMatch);
		canvas.enabled = false;
	}

	void JoinActualMatch(bool success, string info, List<MatchInfoSnapshot> matches) {
		Debug.Log (matches);
		currentMatch = matches.FirstOrDefault ();
		matchMaker.JoinMatch (currentMatch.networkId, "", "", "", 0, 1, NetworkManager.singleton.OnMatchJoined);
	}

	public void DestroyMatch(){
		matchMaker.DestroyMatch (currentMatch.networkId, 1, NetworkManager.singleton.OnDestroyMatch);
	}

}

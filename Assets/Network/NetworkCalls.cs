using UnityEngine.Networking;
using UnityEngine.Networking.Match;

using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


public class NetworkCalls : NetworkBehaviour {

	NetworkMatch matchMaker;

	private MatchInfoSnapshot currentMatch;

	// Use this for initialization
	void Start () {
		NetworkManager.singleton.StartMatchMaker ();
		matchMaker = NetworkManager.singleton.matchMaker;
	}

	/// <summary>
	/// Starts the match.
	/// </summary>
	public void StartMatch(){
		matchMaker.CreateMatch ("room", 2, true, "", "", "", 0, 1, NetworkManager.singleton.OnMatchCreate);
	}

	/// <summary>
	/// Joins the match.
	/// </summary>
	public void JoinMatch(){
		matchMaker.ListMatches (0, 2, "", false, 0, 1, JoinActualMatch);
	}

	/// <summary>
	/// Joins the actual match.
	/// </summary>
	/// <param name="success">If set to <c>true</c> success.</param>
	/// <param name="info">Info.</param>
	/// <param name="matches">Matches.</param>
	void JoinActualMatch(bool success, string info, List<MatchInfoSnapshot> matches) {
		Debug.Log (matches);
		currentMatch = matches.FirstOrDefault ();
		matchMaker.JoinMatch (currentMatch.networkId, "", "", "", 0, 1, NetworkManager.singleton.OnMatchJoined);
	}

	/// <summary>
	/// Destroies the match.
	/// </summary>
	public void DestroyMatch(){
		matchMaker.DestroyMatch (currentMatch.networkId, 1, NetworkManager.singleton.OnDestroyMatch);
	}

}

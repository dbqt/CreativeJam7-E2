using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetManager : NetworkManager {
	
	public override void OnServerAddPlayer(NetworkConnection connection, short id) {
		//base.OnServerAddPlayer (connection, id);
		Debug.Log ("nb : " + this.numPlayers);

		if (this.numPlayers == 0) {
			GameManager.instance.InstantiatePlayer1 ();
		}

		if (this.numPlayers == 1) {
			
		}
			
		
	}

	public override void OnMatchJoined (bool success, string extendedInfo, UnityEngine.Networking.Match.MatchInfo matchInfo)
	{
		Debug.Log ("on match joined");
		base.OnMatchJoined (success, extendedInfo, matchInfo);
		GameManager.instance.InstantiatePlayer2 ();
		GameManager.instance.OnPlayerConnectedToServer (Network.isServer);

	}

	/*public override void OnClientConnect(NetworkConnection connection) {
		GameManager.instance.OnPlayerConnectedToServer (Network.isServer);
	}*/

	
}

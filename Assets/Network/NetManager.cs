using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetManager : NetworkManager {
	public int playerNumber;

	public class NetworkMessage: MessageBase {
		public int playerN;
	}
	
	public override void OnServerAddPlayer(NetworkConnection connection, short id, NetworkReader msg) {
		//base.OnServerAddPlayer (connection, id);
		Debug.Log ("nb : " + this.numPlayers);
		NetworkMessage m = msg.ReadMessage<NetworkMessage> ();
	
		if (m.playerN == 1) {
			Debug.Log ("player server");
			GameObject p1 = GameManager.instance.InstantiatePlayer1 ();
			NetworkServer.AddPlayerForConnection (connection, p1, id);
		} else if (m.playerN == 2) {
			Debug.Log ("player client");
			GameObject p2 = GameManager.instance.InstantiatePlayer2 ();
			NetworkServer.AddPlayerForConnection (connection, p2, id);
		}

		/*if (this.numPlayers == 0) {
			GameManager.instance.InstantiatePlayer1 ();
		}

		if (this.numPlayers == 1) {
		}*/
			
		
	}

	public override void OnClientConnect(NetworkConnection conn) {
		Debug.Log ("on client connect");
		NetworkMessage test = new NetworkMessage ();
		test.playerN = playerNumber;
		ClientScene.AddPlayer (conn, 0, test);
	}

	public override void OnClientSceneChanged(NetworkConnection c){
		//base.OnClientSceneChanged (c);
	}


	/*public override void OnClientConnect(NetworkConnection conn) {
		Debug.Log ("on client connect");
		ClientScene.AddPlayer (conn, 0);
	}*/

	/*public override void OnMatchJoined (bool success, string extendedInfo, UnityEngine.Networking.Match.MatchInfo matchInfo)
	{
		Debug.Log ("on match joined");
		base.OnMatchJoined (success, extendedInfo, matchInfo);
		var player = GameManager.instance.InstantiatePlayer2 ();
		GameManager.instance.OnPlayerConnectedToServer (Network.isServer);


	}*/

	/*public override void OnClientConnect(NetworkConnection connection) {
		GameManager.instance.OnPlayerConnectedToServer (Network.isServer);
	}*/

	
}

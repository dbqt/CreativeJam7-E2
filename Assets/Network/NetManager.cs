using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetManager : NetworkManager {
	public override void OnServerAddPlayer(NetworkConnection connection, short id) {
		base.OnServerAddPlayer (connection, id);
		Debug.Log ("nb : " + this.numPlayers);
		if(this.numPlayers == 2)
			GameManager.instance.OnPlayerConnected ();
	}
	
}

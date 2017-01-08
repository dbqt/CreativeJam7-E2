using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Actionnable : NetworkBehaviour {


	public virtual void FireAction() {
		Debug.Log ("fire action trigger!");

	}
		
    public virtual void IceAction()
    {
        Debug.Log("ice action trigger!");

    }
}

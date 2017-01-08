using UnityEngine;
using UnityEngine.Networking;

using System.Collections;

public class Torch : Actionnable {

    public ParticleSystem Fire;

    public Torch_behavior behavior ;

    public override void FireAction()
    {
        base.FireAction();

        Fire.Play();

		if (isServer) {
			Debug.Log ("im server");
			behavior.toggleTorch (this.gameObject);
		}
    }

    public override void IceAction()
    {
        base.IceAction();

        Fire.Stop();

		if (isServer) {
			Debug.Log ("im server");
			behavior.toggleTorch (this.gameObject);
		} else {
			CmdIceAction ();
		}
	
    }

	[Command]
	public void CmdIceAction(){
		IceAction ();
	}
}

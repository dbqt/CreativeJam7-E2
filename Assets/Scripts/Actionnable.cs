using UnityEngine;
using System.Collections;

public class Actionnable : MonoBehaviour {
	public virtual void FireAction() {
		Debug.Log ("fire action trigger!");
	}

    public virtual void IceAction()
    {
        Debug.Log("ice action trigger!");
    }
}

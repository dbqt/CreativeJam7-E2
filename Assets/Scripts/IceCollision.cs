using UnityEngine;
using System.Collections;

public class IceCollision : MonoBehaviour {
    public void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Actionnable>().IceAction();
    }
}

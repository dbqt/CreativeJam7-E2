using UnityEngine;
using System.Collections;

public class FireCollision : MonoBehaviour {
    public void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Flammable>().FireAction();
    }
}

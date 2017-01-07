using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {
    public void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Flammable>().Action();
    }
}

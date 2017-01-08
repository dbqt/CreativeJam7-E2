using UnityEngine;
using System.Collections;

public class Ice : Actionnable {

    public GameObject roof;
    public GameObject water;

    public override void FireAction()
    {
        base.FireAction();

        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;

        water.GetComponent<MeshRenderer>().enabled = true;
        water.GetComponent<CapsuleCollider>().enabled = true;

        roof.GetComponent<Water_behavior>().toggleWater(this.gameObject, false);
    }
    /*public override void IceAction()
    {
        base.IceAction();

        roof.GetComponent<Water_behavior>().toggleWater(this.gameObject, true);
    }*/
}

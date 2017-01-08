using UnityEngine;
using System.Collections;

public class Ice : Actionnable {

    public GameObject roof;
    public GameObject water;

    public override void FireAction()
    {
        base.FireAction();

       // gameObject.GetComponent<MeshRenderer>().enabled = false;
		gameObject.transform.GetChild(0).gameObject.SetActive(false);

        gameObject.GetComponent<CapsuleCollider>().enabled = false;

        //water.GetComponent<MeshRenderer>().enabled = true;
		water.transform.GetChild(0).gameObject.SetActive(true);

        water.GetComponent<CapsuleCollider>().enabled = true;

        roof.GetComponent<Water_behavior>().toggleWater(water, false);
    }
    /*public override void IceAction()
    {
        base.IceAction();

        roof.GetComponent<Water_behavior>().toggleWater(this.gameObject, true);
    }*/
}

using UnityEngine;
using System.Collections;

public class Water : Actionnable
{
    public GameObject roof;
    public GameObject ice;


    public override void IceAction()
    {
        base.IceAction();

       // gameObject.GetComponent<MeshRenderer>().enabled = false;
		gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.GetComponent<CapsuleCollider>().enabled = false;

        //ice.GetComponent<MeshRenderer>().enabled = true;
		ice.transform.GetChild(0).gameObject.SetActive(true);

        ice.GetComponent<CapsuleCollider>().enabled = true;

        roof.GetComponent<Water_behavior>().toggleWater(this.gameObject, true);
    }
    
    /*public override void FireAction()
    {
        base.FireAction();

        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<CapsuleCollider>().enabled = true;

        roof.GetComponent<Water_behavior>().toggleWater(this.gameObject, false);
    }*/
}

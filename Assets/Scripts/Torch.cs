using UnityEngine;
using System.Collections;

public class Torch : Actionnable {

    public ParticleSystem Fire;

    public GameObject mur;

    public override void FireAction()
    {
        base.FireAction();

        Fire.Play();

        mur.GetComponent<Torch_behavior>().toggleTorch(this.gameObject, true);
    }

    public override void IceAction()
    {
        base.IceAction();

        Fire.Stop();

        mur.GetComponent<Torch_behavior>().toggleTorch(this.gameObject, false);
    }
}

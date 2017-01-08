using UnityEngine;
using System.Collections;

public class Torch : Actionnable {

    public ParticleSystem Fire;

    public Torch_behavior behavior ;

    public override void FireAction()
    {
        base.FireAction();

        Fire.Play();

        behavior.toggleTorch(this.gameObject);
    }

    public override void IceAction()
    {
        base.IceAction();

        Fire.Stop();

        behavior.toggleTorch(this.gameObject);
    }
}

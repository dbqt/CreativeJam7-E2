using UnityEngine;
using System.Collections;

public class Torch : Flammable {

    public ParticleSystem Fire;

    public Torch_behavior behavior ;

    public override void FireAction()
    {
        base.FireAction();

        Fire.Play();

        behavior.toggleTorch(this.gameObject);
    }
}

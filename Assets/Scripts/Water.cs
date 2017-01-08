using UnityEngine;
using System.Collections;

public class Water : Actionnable
{
    public Water_behavior behavior;

    public override void IceAction()
    {
        base.IceAction();

        behavior.toggleWater(this.gameObject);
    }

    // do nothing with fire action
}

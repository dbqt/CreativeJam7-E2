using UnityEngine;
using System.Collections;

public class Ice : Actionnable {

    public Water_behavior behavior;

    public override void FireAction()
    {
        base.FireAction();

        behavior.toggleWater(this.gameObject);
    }

    // do nothing with ice action
}

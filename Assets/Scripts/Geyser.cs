using UnityEngine;
using System.Collections;

public class Geyser : Actionnable {

	public Geyser_behavior gb;

	public override void FireAction()
	{
		base.FireAction();

		gb.toggleCanMove (true);

	}

	public override void IceAction()
	{
		base.IceAction();

		gb.toggleCanMove (false);

	}
}

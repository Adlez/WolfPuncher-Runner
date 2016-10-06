using UnityEngine;
using System.Collections;

public class BunnyBehaviour : ObstacleBehaviour
{
	public override void OnEnable()
	{
		mVelocity = new Vector3(0, 0, 0);
		ob_MinSpeed = 0.25f;
		ob_MaxSpeed = 1.2f;
	}

}

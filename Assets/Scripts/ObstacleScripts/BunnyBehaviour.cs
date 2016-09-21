using UnityEngine;
using System.Collections;

public class BunnyBehaviour : ObstacleBehaviour
{
	public override void OnEnable()
	{
		mVelocity = new Vector3(0, 0, 0);
		mMaxSpeed = 1.2f;
	}

}

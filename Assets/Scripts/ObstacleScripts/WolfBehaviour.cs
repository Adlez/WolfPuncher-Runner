using UnityEngine;
using System.Collections;

public class WolfBehaviour : ObstacleBehaviour 
{
	public override void OnEnable()
	{
		mVelocity = new Vector3(0, 0, 0);
		mMaxSpeed = 4f;
	}
}
/*
public Vector3 mRotation;
	public Vector3 mScaling;

	public GameObject BloodExplosion;

	public float mRotSpeed;

	public float mJumpForce;
	public float mMaxSpeed;
*/
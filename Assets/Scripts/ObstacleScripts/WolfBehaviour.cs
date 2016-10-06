using UnityEngine;
using System.Collections;

public class WolfBehaviour : ObstacleBehaviour 
{
	public override void OnEnable()
	{
		mVelocity = new Vector3(0, 0, 0);
		ob_MinSpeed = 1.5f;
		ob_MaxSpeed = 4f; //Hardcoded temp value
	}

	protected override void OnCollisionEnter2D(Collision2D collision)
	{
		GetComponent<ParticleSystem>().enableEmission = false;
		if (collision.collider.tag == "Ground")
		{
			onGround_ = true;
		}
		if (collision.collider.tag == "Player")
		{
			Instantiate(BloodExplosion, transform.position, transform.rotation);
			Invoke("DestroyObject", 0.0001f);
			collision.collider.GetComponent<Movement>().m_WolvesKilledByCollision += 1;
			//ob_Player.GetComponent<Movement>().m_WolvesKilledByCollision += 1;
			//Debug.Log("Player Collided");
		}
		if (collision.collider.tag == "Fist")
		{
			Instantiate(BloodExplosion, transform.position, transform.rotation);
			Invoke("DestroyObject", 0.0001f);
			collision.collider.GetComponent<Movement>().m_WolvesKilledByFist += 1;
			//Debug.Log("Punched");
		}
		if (collision.collider.tag == "Gust")
		{
			Instantiate(BloodExplosion, transform.position, transform.rotation);
			Invoke("DestroyObject", 0.0001f);
			collision.collider.GetComponent<Movement>().m_WolvesKilledByGust += 1;
			//Debug.Log("Punched");
		}
		if (collision.collider.tag == "TheGreatNothing")
		{
			Invoke("DestroyObject", 0.0001f);
		}
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
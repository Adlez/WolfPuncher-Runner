using UnityEngine;
using System.Collections;

public class ObstacleBehaviour : MonoBehaviour 
{
	public Vector3 mVelocity;
	public Vector3 mRotation;
	public Vector3 mScaling;

	public GameObject BloodExplosion;

	public float mRotSpeed;

	public float mJumpForce;
	public float mMaxSpeed;

	///	Animator mBoredAnim;

	bool onGround_ = true;

	void Start()
	{

	}

	public virtual void OnEnable()
	{

	}
	public virtual void OnDisable()
	{
		CancelInvoke();
	}

	public virtual void DestroyObject()
	{
		gameObject.SetActive(false);
	}

	void OnCollisionEnter2D(Collision2D collision)
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
			//Debug.Log("Player Collided");
		}
		if (collision.collider.tag == "Fist")
		{
			Instantiate(BloodExplosion, transform.position, transform.rotation);
			Invoke("DestroyObject", 0.0001f);
			//Debug.Log("Punched");
		}
		if (collision.collider.tag == "TheGreatNothing")
		{
			Invoke("DestroyObject", 0.0001f);
		}
	}

	// Update is called once per frame

	/*public void UpdateObject()
	{
		GetComponent<Rigidbody2D>().AddForce(-(Vector2.right * mMaxSpeed));
		if (gameObject.GetComponent<Rigidbody2D>().position.y < -25)
		{
			Invoke("DestroyObject", 0.1f);
		}
	}*/

	
	void Update()
	{
		GetComponent<Rigidbody2D>().AddForce(-(Vector2.right * mMaxSpeed));
		if (gameObject.GetComponent<Rigidbody2D>().position.y < -25)
		{
			Invoke("DestroyObject", 0.1f);
		}
	}
}

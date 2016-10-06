using UnityEngine;
using System.Collections;

public class ObstacleBehaviour : MonoBehaviour 
{
	public GameObject ob_Player;
	public Vector3 mVelocity;
	public Vector3 mRotation;
	public Vector3 mScaling;

	public GameObject BloodExplosion;

	public float mRotSpeed;

	public float mJumpForce;
	public float ob_MinSpeed;
	public float ob_MaxSpeed;
	public float ob_CurSpeed;

	///	Animator mBoredAnim;

	protected bool onGround_ = true;

	void Start()
	{

	}

	public virtual void OnEnable()
	{
		ob_CurSpeed = Random.Range(ob_MinSpeed, ob_MaxSpeed);
	}
	public virtual void OnDisable()
	{
		CancelInvoke();
	}

	public virtual void DestroyObject()
	{
		gameObject.SetActive(false);
	}

	protected virtual void OnCollisionEnter2D(Collision2D collision)
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
		GetComponent<Rigidbody2D>().AddForce(-(Vector2.right * ob_CurSpeed));
		if (gameObject.GetComponent<Rigidbody2D>().position.y < -25)
		{
			Invoke("DestroyObject", 0.1f);
		}
	}
}

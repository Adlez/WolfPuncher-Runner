using UnityEngine;
using System.Collections;

public class Fist : MonoBehaviour 
{
	public ObstacleBehaviour f_ObstacleBehaviour;
	public GameObject f_Mayor;
	public Animator mBoredAnimator;

	private int mTempKilled;

	public GameObject BloodExplosion;

	public Vector2 speed;

	// Use this for initialization
	void Start () 
	{
		f_Mayor = GameObject.FindGameObjectWithTag("Player").gameObject;
		float forceOfFist = f_Mayor.GetComponent<Movement>().m_PunchForce * 0.1f;
		speed.x = forceOfFist;
		GetComponent<Rigidbody2D>().velocity = transform.position.x * speed;
		f_Mayor.GetComponent<Movement>().m_PunchForce = 0;
	}
	
	// Update is called once per frame
	void Update()
	{

	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Wolf")
		{
			//mMovement.GetComponent<Movement>().WolfKilled();
			mBoredAnimator.SetFloat("Boredom", 0.0f);
			//Movement.tempBored = 0.0f;
			//f_ObstacleBehaviour.GetComponent<ObstacleBehaviour>().DestroyObject();
			//Instantiate(BloodExplosion, transform.position, transform.rotation);
			//Destroy(collider.gameObject);
		}
	}
}

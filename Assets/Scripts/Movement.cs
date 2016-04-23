using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public GameObject m_GameController;

	public MayorStats mMayorStats;

	public Transform mFistSpawn;
	public GameObject mFist;

	public float m_PunchRate;
	private float m_NextPunch;

	public Vector3 mVelocity;
	public Vector3 mRotation;
	public Vector3 mScaling;

	public Animator mAnimator;
	public Animator mIritAnimator;
	public Animator mSadAnimator;
	public Animator mBoredAnimator;

	public float mRotSpeed;
	public float mMaxSpeed;

	public bool mFacingRight;
    public bool m_ReadyToJump;

	public float mJumpForce;

	public bool OnGround
	{
		get
		{
			return onGround_;
		}
		set
		{
			onGround_ = value;
		}
	}

	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		//Debug.Log(m_Boredom);
		
		if (Input.GetButton("Fire1") && Time.time > m_NextPunch)
		{
			m_NextPunch = Time.time + m_PunchRate;
			Instantiate(mFist, mFistSpawn.position, mFistSpawn.rotation);
		}
		//Instantiate (mFist, mFistSpawn.position, mFistSpawn.rotation);

		
	}

	void FixedUpdate()
	{
		//------------Transform Example-------------------------

		/*transform.position += mVelocity;
		transform.Rotate(mRotation);
		transform.localScale = new Vector3(transform.localScale.x * mScaling.x,
										   transform.localScale.y * mScaling.y,
										   transform.localScale.z * mScaling.z);
		 */
        /*
		if(Input.GetAxis("Horizontal") < 0) //turns her around
		{
			mFacingRight = false;
			var direction = -1f;
			transform.localScale = new Vector3(direction, 1, 1);
		}
			//Add option for idle animation here (Else If Horizontal > 0)
			//then else
		else
		{ 
			mFacingRight = true;
			var direction = 1;
			transform.localScale = new Vector3(direction, 1, 1);
		}*/
		//--------------Rigidbody2D Example----------------------
        //rigidbody2D.AddForce(Vector2.right * Input.GetAxis("Horizontal") * mMaxSpeed);
		// rigidbody2D.AddForceAtPosition(Vector2.right, new Vector2(transform.position.x, 
		//                                 transform.position.y + 1.0f));

		if (onGround_ && Input.GetAxis("Jump") > 0)
		{
            float maxJump = mMayorStats.GetComponent<MayorStats>().MAXJUMPFORCE;
            if(mJumpForce < maxJump)
            {
                mJumpForce++;
                mJumpForce = mJumpForce*2;
                if (mJumpForce < maxJump)
                {
                    mJumpForce = maxJump;
                }
            }
            m_ReadyToJump = true;
		}
        else if (Input.GetAxis("Jump") <= 0 && m_ReadyToJump)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * mJumpForce);
            mAnimator.SetBool("IsJumping", true);
            onGround_ = false;
            m_ReadyToJump = false;
        }
		// rigidbody2D.AddTorque(mRotSpeed * Input.GetAxis("Horizontal"));
	}

	bool onGround_ = true;
	void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.collider.tag == "Ground")
		{
			onGround_ = true;
			mAnimator.SetBool("IsJumping", false);
		}
		
		if (collision.collider.tag == "Wolf")
		{
//			Instantiate(BloodExplosion, transform.position, transform.rotation);
//			tempMad += 0.5f;
//			mIritAnimator.SetFloat("Irritation", tempMad);
		}
		if (collision.collider.tag == "Bunny")
		{
//			Instantiate(BloodExplosion, transform.position, transform.rotation);
//			tempSad += 1;
//			mSadAnimator.SetInteger("Sadness", tempSad);
		} 
	}

	/*void OnCollisionStay2D(Collider2D other)
	{
		Debug.Log("OnTriggerStay");
	}

	void OnCollisionExit2D(Collider2D other)
	{
		Debug.Log("OnTriggerExit");
	}*/

	void OnCollisionEnter2D(Collider2D other)
	{
		Debug.Log("OnTriggerEnter");
	}

}



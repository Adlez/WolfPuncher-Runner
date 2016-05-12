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
    private bool onGround_ = true;


    public float mJumpForce;
    public float m_JumpIncr;

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
        m_JumpIncr = 850;
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
            mJumpForce += m_JumpIncr;

            if (mJumpForce >= maxJump)
            {
                mJumpForce = maxJump;
            }

            m_ReadyToJump = true;
		}
        else if (Input.GetAxis("Jump") <= 0 && m_ReadyToJump)
        {
            float min_JumpForce = mMayorStats.GetComponent<MayorStats>().MINJUMPFORCE;

            if (mJumpForce + min_JumpForce >= mMayorStats.GetComponent<MayorStats>().MAXJUMPFORCE)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * (mMayorStats.GetComponent<MayorStats>().MAXJUMPFORCE));
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * (mJumpForce + min_JumpForce));
            }
            mAnimator.SetBool("IsJumping", true);
            onGround_ = false;
            m_ReadyToJump = false;
            mJumpForce = 0;
        }
		// rigidbody2D.AddTorque(mRotSpeed * Input.GetAxis("Horizontal"));
	}

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



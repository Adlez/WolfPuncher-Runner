using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public GameObject m_GameController;

	public MayorStats m_MayorStats;

    public Transform m_PlayerLocation;
    public Transform m_RayEnd;

	public Transform m_FistSpawn;
	public GameObject m_Fist;

	public float m_PunchRate;
	private float m_NextPunch;

	public Vector3 mVelocity;
	public Vector3 mRotation;
	public Vector3 mScaling;

	public Animator mAnimator;
	public Animator mIritAnimator;
	public Animator mSadAnimator;
	public Animator mBoredAnimator;

    public RaycastHit2D m_AbovePlatform;

	public float mMaxSpeed;

    public bool m_ReadyToJump;
    public bool m_PlatformAbove;
    private bool onGround_ = true;

    public float m_JumpForce;
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
        if (this.transform.position.x < -4.85)
        {
            //this.transform.position.x = -4.85;
        }
		
		if (Input.GetButton("Fire1") && Time.time > m_NextPunch)
		{
			m_NextPunch = Time.time + m_PunchRate;
			Instantiate(m_Fist, m_FistSpawn.position, m_FistSpawn.rotation);
		}

		if (onGround_ == false)
		{
			mAnimator.SetBool("IsJumping", true);
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
        Raycasting(); //Checking for platforms to disable

		if (onGround_ && Input.GetAxis("Jump") > 0)
		{
            float maxJump = m_MayorStats.GetComponent<MayorStats>().MAXJUMPFORCE;
            m_JumpForce += m_JumpIncr;

            if (m_JumpForce >= maxJump)
            {
                m_JumpForce = maxJump;
            }

            m_ReadyToJump = true;
		}
        else if (Input.GetAxis("Jump") <= 0 && m_ReadyToJump)
        {
            float min_JumpForce = m_MayorStats.GetComponent<MayorStats>().MINJUMPFORCE;

            if (m_JumpForce + min_JumpForce >= m_MayorStats.GetComponent<MayorStats>().MAXJUMPFORCE)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * (m_MayorStats.GetComponent<MayorStats>().MAXJUMPFORCE));
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * (m_JumpForce + min_JumpForce));
            }
            mAnimator.SetBool("IsJumping", true);
            onGround_ = false;
            m_ReadyToJump = false;
            m_JumpForce = 0;
        }
		// rigidbody2D.AddTorque(mRotSpeed * Input.GetAxis("Horizontal"));
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.collider.tag == "Ground")
		{
			if (onGround_ == false)
			{
				onGround_ = true;
				mAnimator.SetBool("IsJumping", false);
			}
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

	/*
	void OnCollisionEnter2D(Collider2D other)
	{
		
		Debug.Log("OnTriggerEnter");
	}*/

    void Raycasting()
    {
        Debug.DrawLine(m_PlayerLocation.position, m_RayEnd.position, Color.red);
        m_AbovePlatform = Physics2D.Linecast(m_PlayerLocation.position, m_RayEnd.position, 1 << LayerMask.NameToLayer("Ground"));//, null, out hit);        
        //Detects if platform is above the player
        if (m_AbovePlatform != false)
        {
            m_AbovePlatform.collider.enabled = false;
            Debug.Log("Platform Passable");
        }        
        //Disables the collider to allow passage through on the way up
        //still need to turn it off on the way down,
        //perhaps a raycast on all platforms to detect if the player is above them, and if so turn it back on?
    }

    void ColliderKiller()
    {

    }

}



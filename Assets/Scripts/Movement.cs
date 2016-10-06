using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour //technically: MayorController
{
    public GameObject m_GameController;
	public MayorStats m_MayorStats;

    public Transform m_PlayerLocation;
	public Transform m_BelowRayEnd;
    public Transform m_AboveRayEnd;

	public Transform m_FistSpawn;
	public GameObject m_Fist;

	public float m_PunchRate;
	private float m_NextPunch;
	public float m_PunchForce;

	public Vector3 mVelocity;
	public Vector3 mRotation;
	public Vector3 mScaling;

	Vector2 _LastPos;
	Vector2 _CurPos;

	public Animator mAnimator;
	public Animator mIritAnimator;
	public Animator mSadAnimator;
	public Animator mBoredAnimator;

    public RaycastHit2D m_AbovePlatform;
	public RaycastHit2D m_PlatformBelow;

	public float mMaxSpeed;

    public bool m_ReadyToJump;
    public bool m_PlatformAbove;

	public bool m_RunLeft;
	public bool m_FacingRight;
    private bool onGround_ = true;

    public float m_JumpForce;
    public float m_JumpIncr;

	public int m_WolvesKilledByFist;
	public int m_WolvesKilledByGust;
	public int m_WolvesKilledByCollision;
	public int m_WolvesKilledByKO;

	public int m_TotalWolvesKilled;

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

	public void TurnAround()
	{
		if (m_FacingRight) //turns her around
		{
			m_FacingRight = false;
			var direction = -1f;
			transform.localScale = new Vector3(direction, 1, 1);
		}
		//Add option for idle animation here (Else If Horizontal > 0)
		//then else
		else
		{
			m_FacingRight = true;
			var direction = 1;
			transform.localScale = new Vector3(direction, 1, 1);
		}
	}

	void MoveJumpAndMore()
	{
		//------------Transform Example-------------------------
		mVelocity.x = m_MayorStats.GetComponent<MayorStats>().m_Acceleration;
		transform.position += mVelocity;
		/*transform.Rotate(mRotation);
		transform.localScale = new Vector3(transform.localScale.x * mScaling.x,
										   transform.localScale.y * mScaling.y,
										   transform.localScale.z * mScaling.z);
		 */


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

		if (m_NextPunch > 0)
		{
			m_NextPunch -= Time.deltaTime;
		}
		//Debug.Log(m_Boredom);
		if (this.transform.position.x < 0)
		{
			//this.transform.position.x = 0f;
		}
		//if (Input.GetButton("Fire1") && Time.time > m_NextPunch)
		if (Input.GetButton("Fire1") && m_NextPunch <= 0)
		{
			m_PunchForce += Time.deltaTime;
		}
		else if (Input.GetButtonUp("Fire1") && m_PunchForce > 0 && m_NextPunch <= 0)
		{
			m_NextPunch += m_PunchRate;

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
		if (m_GameController.GetComponent<GameController>().gc_GameIsPaused)
		{
			mAnimator.enabled = false;
			return;
		}
		else
		{
			mAnimator.enabled = true;
			MoveJumpAndMore();
		}

		//Checking for movement
		_CurPos = this.gameObject.transform.position;
		if (_CurPos == _LastPos)
		{
			//If not moving, assume stuck in a collider and push them up
			print("Not moving");
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * (1.2f));
			this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 15);
		}
		_LastPos = _CurPos;

		m_TotalWolvesKilled = m_WolvesKilledByCollision + m_WolvesKilledByFist + m_WolvesKilledByGust + m_WolvesKilledByKO;
		m_GameController.GetComponent<GameController>().gc_ScoreDisplay.text = m_TotalWolvesKilled.ToString();
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		var mStats = m_MayorStats.GetComponent<MayorStats>();
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
			mStats.tempMad += 0.5f;
			mIritAnimator.SetFloat("Irritation", mStats.tempMad);
		}
		if (collision.collider.tag == "Bunny")
		{
//			Instantiate(BloodExplosion, transform.position, transform.rotation);
			mStats.tempSad += 1;
			mSadAnimator.SetInteger("Sadness", mStats.tempSad);
		}
	}

	void Raycasting()
	{
		Debug.DrawLine(m_PlayerLocation.position, m_AboveRayEnd.position, Color.red);
		m_AbovePlatform = Physics2D.Linecast(m_PlayerLocation.position, m_AboveRayEnd.position, 1 << LayerMask.NameToLayer("GroundPlus"));//, null, out hit);        
		//Detects if platform is above the player
		if (m_AbovePlatform != false)
		{
			m_AbovePlatform.collider.enabled = false;
			Debug.Log("Platform Passable, collider Disabled");
		}

		Debug.DrawLine(m_PlayerLocation.position, m_AboveRayEnd.position, Color.red);
		m_PlatformBelow = Physics2D.Linecast(m_PlayerLocation.position, m_BelowRayEnd.position, 1 << LayerMask.NameToLayer("GroundPlus"));
		if (m_PlatformBelow != false)
		{
			m_PlatformBelow.collider.enabled = true;
			Debug.Log("Platform Collider Enabled");
		}

		//Disables the collider to allow passage through on the way up
		//still need to turn it off on the way down,
		//perhaps a raycast on all platforms to detect if the player is above them, and if so turn it back on?
	}

	void ColliderKiller()
	{

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
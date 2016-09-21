using UnityEngine;
using System.Collections;

public class GroundController : MonoBehaviour 
{
    //public Transform grnd_ThisPlatformLoc;
    public Transform grnd_EndOfRay;
	public Transform grnd_BeginningOfRay;
	public GameObject grnd_ThisPlatform;
    public Vector3 rayStartOffset = new Vector3(0.0f, -0.5f, 0.0f);

    RaycastHit2D grnd_PlayerHit;
	public bool grnd_PlayerAbove;

    public void DelayedStart() //Delay this start function until we know everything we need is assigned properly in LevelPlacer
    {
		grnd_PlayerAbove = false;
		grnd_ThisPlatform = this.gameObject;
		//grnd_ThisPlatformLoc = grnd_ThisPlatform.transform;
		if (grnd_BeginningOfRay == null)
		{
			grnd_BeginningOfRay = this.GetComponent<LevelPlacer>().lp_RayStartPrefab;
			grnd_EndOfRay = this.GetComponent<LevelPlacer>().lp_RayEndPrefab;
		}
		grnd_ThisPlatform.GetComponent<BoxCollider2D>().enabled = false;

		grnd_BeginningOfRay.transform.position = new Vector2(this.transform.position.x -10, this.transform.position.y +0.87f); //Set to initial position here
		grnd_EndOfRay.transform.position = new Vector2(this.transform.position.x + 10, this.transform.position.y + 0.87f); //Set to initial position here
		//change these HArd coded values to a constans folder later

		if (this.gameObject.transform.localScale.y != 1)
		{
			//rayStartOffset.y *= this.gameObject.transform.localScale.y;
			rayStartOffset.y = 1;
		}
    }

    void Update()
    {
        //newPosition.x += Time.deltaTime * scrollSpeed;
        //transform.position = newPosition;
        Raycasting();
		if (grnd_PlayerAbove)
		{
			grnd_ThisPlatform.GetComponent<BoxCollider2D>().enabled = true;
		}

		
        //Debug.DrawLine(grnd_ThisPlatformLoc.position, grnd_EndOfRay.position);
    }

    void Raycasting()
    {
		Debug.DrawLine(grnd_BeginningOfRay.position, grnd_EndOfRay.position, Color.blue);
		grnd_PlayerAbove = Physics2D.Linecast(grnd_BeginningOfRay.position + rayStartOffset, grnd_EndOfRay.position, 1 << LayerMask.NameToLayer("Player"));//, null, out hit);        
		if (grnd_PlayerAbove)
		{
			grnd_ThisPlatform.GetComponent<BoxCollider2D>().enabled = true;
		}
        //Debug.Log("platform solid");
    }
/*
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Player")
		{
			for(int i = 0; i < m_BGController.Length; ++i)
			{
				m_BGController[i].GetComponent<BGController>().ChangeSetting(m_ThisSettingName);
			}
		}
	}*/
}

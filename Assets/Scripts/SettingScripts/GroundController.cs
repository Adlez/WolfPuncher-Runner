using UnityEngine;
using System.Collections;

public class GroundController : MonoBehaviour 
{
    public Transform grnd_ThisPlatformLoc;
    public Transform grnd_EndOfRay;
	public GameObject grnd_ThisPlatform;
	public GameObject[] m_BGController = new GameObject[4];
    public Vector3 rayStartOffset = new Vector3(0.0f, -0.5f, 0.0f);

    RaycastHit2D grnd_PlayerHit;

	public string m_ThisSettingName;
    public float scrollSpeed;

    private Vector3 newPosition;

    void Start()
    {
        newPosition = transform.position;
    }

    void Update()
    {
        newPosition.x += Time.deltaTime * scrollSpeed;
        transform.position = newPosition;
        Raycasting();
        //Debug.DrawLine(grnd_ThisPlatformLoc.position, grnd_EndOfRay.position);
    }

    void Raycasting()
    {
        //Debug.DrawLine(grnd_ThisPlatformLoc.position, grnd_EndOfRay.position, Color.blue);
        grnd_PlayerHit = Physics2D.Linecast(grnd_ThisPlatformLoc.position + rayStartOffset, grnd_EndOfRay.position, 1 << LayerMask.NameToLayer("PlayerFeet"));//, null, out hit);        
        grnd_ThisPlatform.GetComponent<BoxCollider2D>().enabled = true;
        //Debug.Log("platform solid");
    }

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Player")
		{
			for(int i = 0; i < m_BGController.Length; ++i)
			{
				m_BGController[i].GetComponent<BGController>().ChangeSetting(m_ThisSettingName);
			}
		}
	}
}

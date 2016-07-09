using UnityEngine;
using System.Collections;

public class BGController : MonoBehaviour 
{
	public GameObject m_GameController;
	public Vector3 mVelocity;
	public Vector2 speed;

	public float scrollSpeed;
	private float backgroundWidth;
	private bool _bgIsRecycling;

	private Transform backgroundTransform;
	private Vector3 newPosition;

	void Awake()
	{
		newPosition = transform.position;
		backgroundTransform = Camera.main.transform;

		SpriteRenderer spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
		backgroundWidth = spriteRenderer.sprite.bounds.size.x;
	}

	public void ChangeSetting(string newSetting)//string newSetting)
	{
		if (newSetting == "")
		{
			m_GameController.GetComponent<GameController>().m_CurSetting = this.name + "";//newSetting;
			Debug.Log(m_GameController.GetComponent<GameController>().m_CurSetting);

			m_GameController.GetComponent<GameController>().SwapBackgrounds(this.name);
		}
		else
		{
			m_GameController.GetComponent<GameController>().SwapBackgrounds(newSetting);
		}
	}

	void Update()
	{
		newPosition.x += Time.deltaTime * scrollSpeed;
		transform.position = newPosition;

		if ((transform.position.x + backgroundWidth) < backgroundTransform.position.x)
		{
			Vector3 newPos = transform.position;
			newPos.x += 1.98f * backgroundWidth;
			transform.position = newPos;
			newPosition = newPos;
		}

		GetComponent<Rigidbody2D>().velocity = mVelocity.x * speed;
	}
}

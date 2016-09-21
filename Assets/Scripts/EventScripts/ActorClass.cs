using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActorClass : MonoBehaviour 
{
	GameObject ac_ThisActor;
	public string ac_Name;
	public List<Sprite> ac_Portraits;
	public List<GameObject> ac_Emotes;

	
	Transform ac_PosOnScreen;
	public Sprite ac_CurPortrait;

	bool ac_IsVisible;

	void Awake()
	{
		ac_ThisActor = this.gameObject;
		ac_Name = this.gameObject.name;
		SpriteRenderer renderer = ac_ThisActor.AddComponent<SpriteRenderer>();
		//populate ac_Portraits
	}

	public void EarlyStart()
	{
		//ac_ThisActor = this.gameObject;
		//ac_Name = this.gameObject.name;
		//SpriteRenderer renderer = ac_ThisActor.AddComponent<SpriteRenderer>();
	}
	// Update is called once per frame
	void Update () 
	{
		ac_ThisActor.GetComponent<SpriteRenderer>().sprite = ac_CurPortrait;

		if (ac_IsVisible)
		{
			ac_ThisActor.SetActive(true);
		}
		else
		{
			ac_ThisActor.SetActive(false);
		}
	}

	public void Perform(Vector2 position, int startPortrait)
	{
		ac_ThisActor.transform.position = position;
		ac_CurPortrait = ac_Portraits[startPortrait];
		ac_IsVisible = true;
		ac_ThisActor.SetActive(true);
	}

	public void SwapPortrait(int newPID)
	{
		ac_CurPortrait = ac_Portraits[newPID];
	}
}

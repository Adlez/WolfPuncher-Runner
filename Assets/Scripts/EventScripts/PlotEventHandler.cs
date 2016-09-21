using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlotEventHandler : MonoBehaviour 
{
	public Canvas peh_StoryCanvas;
	public List<GameObject> peh_CastOfCharacters;
	public GameObject peh_GameEventList;
	public GameObject peh_CastingCouch;
	public GameObject peh_DialogueObject;

	public GameObject peh_CHPanelLeft;
	public GameObject peh_CHPanelRight;
	public GameObject peh_CHPanelMid;

	void Awake()
	{
		for (int i = 0; i < peh_CastingCouch.transform.childCount; ++i)
		{
			peh_CastOfCharacters.Add(peh_CastingCouch.transform.GetChild(i).gameObject);
		}
		
	}
	//eventID corresponds to which Character(s) (in the list peh_CharacterDatai) will appear in the "scene"
	//as well as the numericalID of the event (from 0 - who knows what number)
	//Gonna need to give the number of characters we'll be looking for in the "scene" too
	//example: ID(eventID)CH(numOfChars)MA(firstChar)--- Nah. Can't do it. Probably gonna need to pass the event ID into another object
	//using another function to return the number of characters and which ones they are

	//ehhhhhhhhhh, make a gameobject to hold the events which are also gameobjects

	public void BeginEvent(int eventID)
	{
		for (int i = 0; i < peh_CastOfCharacters.Count; ++i)
		{
			peh_CastOfCharacters[i].GetComponent<ActorClass>().EarlyStart();
		}
		if (eventID == 0001)
		{
			PlayEvent0001();
		}
		
	}

	public void PlayEvent0001()
	{
		peh_DialogueObject.GetComponent<Dialogue>().d_DialogueStrings.Clear();
		peh_DialogueObject.GetComponent<Dialogue>().d_DialogueStrings.Add("Insert Dialogue from ext file.");
		//Insert Dialogue from an external file
		peh_DialogueObject.GetComponent<Dialogue>().d_DialogueStrings.Add("Please insert Dialogue.");

		peh_CastOfCharacters[0].GetComponent<ActorClass>().Perform(peh_CHPanelLeft.transform.position, 0);
		peh_CHPanelLeft.GetComponent<Image>().sprite = peh_CastOfCharacters[0].GetComponent<ActorClass>().ac_CurPortrait;
		peh_CastOfCharacters[1].GetComponent<ActorClass>().Perform(peh_CHPanelRight.transform.position, 0);
		peh_CHPanelRight.GetComponent<Image>().sprite = peh_CastOfCharacters[1].GetComponent<ActorClass>().ac_CurPortrait;
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EventTrigger : MonoBehaviour 
{
	public GameObject et_GameController;
	public GameObject et_EventCanvas;
	public GameObject et_EventHandler;

	public bool et_HasBeenActiveThisRun;

	public int et_EventID;

	void OnCollisionEnter2D(Collision2D collision)
	{
		
		if (collision.collider.tag == "Player")
		{
			//Really this should call a function inside PlotEventHandler to do all this
			et_EventCanvas.SetActive(true);
			et_GameController.GetComponent<GameController>().PauseGame();
			//Time.timeScale = 0; //Remember to set this back to 1 once the event is finished
			et_EventHandler.GetComponent<PlotEventHandler>().PlayEvent0001();
		}
		
	}
	// Use this for initialization
	void Start () {
	
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public GameObject gc_WorldContainer;
	public GameObject gc_CurLevel;
	public GameObject gc_CurLevelSection;
	public GameObject gc_EventCanvas;
	//probly gonna have to have access to literally every game object with a script attached to them
	public GameObject gc_TheMayor;
	public GameObject gc_AudioPlayer;
	//public List<GameObject> gc_ObjSpawners;
	public Text gc_ScoreDisplay;

	public string m_CurSetting;
	public List<string> m_Settings;

	private bool m_GameOver;
	private bool m_Restart;

	public bool gc_GameIsPaused;

	public Text restartText;
	public Text gameOverText;
	public Text wolvesKilledText;

	public static int m_WolvesKilled = 0;

	// Use this for initialization
	void Start () 
	{
		//get ALL the damned start functions from EVERY other object and make it so they will all activate  here
		m_GameOver = false;
		m_Restart = false;

		gc_EventCanvas.SetActive(false);
		gc_AudioPlayer.GetComponent<AudioScript>().PlayMusic();

		//restartText.text = "";
		//gameOverText.text = "";
		//wolvesKilledText.text = "0";
	}

	public void PauseGame()
	{
		gc_GameIsPaused = !gc_GameIsPaused;
		if (gc_GameIsPaused != true)
		{
			//gc_AudioPlayer.GetComponent<AudioScript>().PlayMusic();
		}
	}

	public void UpdateAllObjects()
	{
		if (gc_GameIsPaused)
		{
			if (gc_WorldContainer.GetComponent<SpawnControllerScript>().sc_SpawnersActive == true)
			{
				gc_WorldContainer.GetComponent<SpawnControllerScript>().DeactivateAllSpawners();
			}
		}
		else
		{
			if (gc_WorldContainer.GetComponent<SpawnControllerScript>().sc_SpawnersActive == false)
			{
				gc_WorldContainer.GetComponent<SpawnControllerScript>().ActivateSpawners();
			}
		}
	}
	// Update is called once per frame
	void Update() 
	{
		//get ALL the damned UPDATE functions from EVERY other object and make it so they will only activate here and we can keep track of when updates happen
		//wolvesKilledText.text = "" + m_WolvesKilled;
		UpdateAllObjects();
		
		if (m_Restart)
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over";
		m_GameOver = true;
		restartText.text = "Press 'R' to restart.";
		m_Restart = true;
	}
}
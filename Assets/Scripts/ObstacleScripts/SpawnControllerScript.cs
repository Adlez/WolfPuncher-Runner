using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnControllerScript : MonoBehaviour 
{
	//ldf_WorldContainer.GetComponent<SpawnControllerScript>().ActivateSpawners(ldf_ThisLevel);
	public List<GameObject> m_Spawners;
	public List<string> m_SpawnerNames;

	public List<string> sc_ForestObstacles;
	public List<string> sc_GrasslandObstacles;

	public GameObject sc_CurLevel;
	public string sc_CurLevelName;

	public bool sc_SpawnersActive;

	// Use this for initialization
	void Awake()
	{
		DeactivateAllSpawners();
	}

	void Start () 
	{
		sc_ForestObstacles.Add("Wolf");
		sc_ForestObstacles.Add("Bunny");

		sc_GrasslandObstacles.Add("Wolf");
		//ActivateSpawners(m_SpawnerNames);
	}

	void Update()
	{
		if (sc_CurLevel != this.gameObject.GetComponent<LevelPlacer>().lp_CurLevel)
		{
			sc_CurLevel = this.gameObject.GetComponent<LevelPlacer>().lp_CurLevel;
			//ActivateSpawners();
		}
		
	}

	public void DeactivateAllSpawners()
	{
		for (int i = 0; i < m_Spawners.Count; ++i)
		{
			if (m_Spawners[i] != null)
			{
				m_Spawners[i].SetActive(false);
			}
		}
		sc_SpawnersActive = false;
	}

	public void ActivateSpawners()
	{
		DeactivateAllSpawners();
		List<string> spawnersToBeActivated = sc_ForestObstacles;
		spawnersToBeActivated.Clear();

		if (sc_CurLevel != null)
		{
			if (sc_CurLevel.name == "Level-Forest")
			{
				spawnersToBeActivated = sc_ForestObstacles;
			}
			if (sc_CurLevel.name != "Level-Forest")
			{
				spawnersToBeActivated = sc_GrasslandObstacles;
			}
		}

		//List<string> spawners = activespawners;
		for (int j = 0; j < m_Spawners.Count; ++j)
		{
			for (int i = 0; i < spawnersToBeActivated.Count; ++i)
			{
				string obstacleName = spawnersToBeActivated[i] + "Pool";
				if (m_Spawners[i].name == obstacleName)
				{
					m_Spawners[i].SetActive(true);
				}
			}
		}

		sc_SpawnersActive = true;
	}
}
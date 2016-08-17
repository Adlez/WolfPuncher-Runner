using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnControllerScript : MonoBehaviour 
{
	public List<GameObject> m_Spawners;
	public List<string> m_SpawnerNames;

	// Use this for initialization
	void Start () 
	{
		DeactivateAllSpawners();
		//ActivateSpawners(m_SpawnerNames);
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
	}

	public void ActivateSpawners(List<string> spawners)
	{
		DeactivateAllSpawners();

		List<string> activespawners = spawners;

		for(int i = 0; i < activespawners.Count; ++i)
		{
			for (int j = 0; j < m_Spawners.Count; ++j)
			{
				if (m_Spawners[i].name == spawners[j])
				{
					m_Spawners[i].SetActive(true);
				}
			}
		}
	}
}
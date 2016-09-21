//Obsolete code, not used anymore
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WolfSpawner : MonoBehaviour 
{
	/*public List<Transform> w_WolfSpawnPos;
	public float minSpawnTime = 1.5f;
	public float maxSpawnTime = 10f;

	public int WolvesOnScreen;
	int MaxWolves = 1;
	int gameClock = 0;

	void SpawnObj()
	{
		//Vector3 ObjPos = w_WolfSpawnPos[0];
		GameObject obj = Objectpooler.current.GetPooledObject();

		if (obj == null) return;

		obj.transform.position = w_WolfSpawnPos[0].position;
		obj.transform.rotation = transform.rotation;
		obj.SetActive(true);
		++WolvesOnScreen;
	}
	
	// Update is called once per frame
	void Update () 
	{
	//	gameClock = (int)Time.deltaTime;
		gameClock = 1;
		if (WolvesOnScreen < MaxWolves)
		{
			for (int i = 0; i < MaxWolves; ++i)
			{
				Debug.Log(WolvesOnScreen);
			
				//InvokeRepeating("SpawnObj", minSpawnTime, maxSpawnTime);
			}
			
		}
		

		if (gameClock > 2600)
		{
			MaxWolves = 7;
		}
		else if (gameClock > 2150)
		{
			MaxWolves = 6;
		}
		else if (gameClock > 1700)
		{
			MaxWolves = 5;
		}
		else if (gameClock > 1350)
		{
			MaxWolves = 4;
		}
		else if (gameClock > 900)
		{
			MaxWolves = 3;
		}
		else if (gameClock > 450)
		{
			MaxWolves = 2;
		}
		else
		{
			MaxWolves = 1;
		}
		
	}*/
}

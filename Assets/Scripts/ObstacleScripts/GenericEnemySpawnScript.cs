using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenericEnemySpawnScript : MonoBehaviour 
{
	public float minSpawnTime;
	public float maxSpawnTime;

	public GameObject m_ObjPooler;
	public GameObject m_SpawnLocation;

	//public string m_CurSetting;
	void Start () 
	{
		InvokeRepeating("SpawnObj", minSpawnTime, maxSpawnTime);
	}

	void SpawnObj()
	{
		Vector3 ObjPos = m_SpawnLocation.transform.position;
		GameObject obj = m_ObjPooler.GetComponent<GenericEnemyPooler>().GetPooledObject();

		if (obj == null) 
			return;

		GetCurSetting();

		if (obj.name == "WolfPlusBlood")
		{
			//minSpawnTime = 3;
			//maxSpawnTime = Random.Range(5, 35);
		}
		else
		{
			//minSpawnTime = 3;
			//maxSpawnTime = Random.Range(5, 10);
		}

		obj.transform.position = ObjPos;
		obj.transform.rotation = transform.rotation;
		obj.SetActive(true);

	}

	void GetCurSetting()
	{

	}
}
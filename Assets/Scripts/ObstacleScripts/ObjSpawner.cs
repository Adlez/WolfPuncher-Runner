using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjSpawner : MonoBehaviour 
{
	public float minSpawnTime;
	public float maxSpawnTime;

    public GameObject m_ObjectPooler;
    public GameObject m_SpawnLocation;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("SpawnObj", minSpawnTime, maxSpawnTime);
	}

	void SpawnObj()
	{
        Vector3 ObjPos = m_SpawnLocation.transform.position;
		GameObject obj = Objectpooler.current.GetPooledObject();
        //GameObject obj = m_ObjectPooler.GetComponent<ObjectPooler>().GetPooledObject();

		if (obj == null) return;

		obj.transform.position = ObjPos;
		obj.transform.rotation = transform.rotation;
		obj.SetActive(true);

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}

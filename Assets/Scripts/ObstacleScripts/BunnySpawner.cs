//Obsolete code, not used anymore
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BunnySpawner : MonoBehaviour 
{
	public float minSpawnTime;
	public float maxSpawnTime;

    public GameObject bunnyPooler;
    public GameObject m_SpawnLocation;

	// Use this for initialization
	void Start () 
	{
		//InvokeRepeating("SpawnObj", minSpawnTime, maxSpawnTime);
	}

	void SpawnObj()
	{
        Vector3 ObjPos = m_SpawnLocation.transform.position;
        GameObject obj = bunnyPooler.GetComponent<BunnyPooler>().GetPooledObject();
        //GameObject obj = BunnyPooler.current.GetPooledObject();

		if (obj == null) return;

		obj.transform.position = ObjPos;
		obj.transform.rotation = transform.rotation;
		obj.SetActive(true);

	}
}

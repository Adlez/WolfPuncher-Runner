using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenericEnemyPooler : MonoBehaviour 
{
    public static GenericEnemyPooler current;
    public GameObject m_ObjPool;
    public int pooledAmount;
    public bool willGrow = true; //cannot remove so when new ones are added they'll never leave

    public List<GameObject> pooledObjects;

    void Awake()
    {
        current = this;
    }


    // Use this for initialization
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; ++i)
        {
            GameObject enemy = (GameObject)Instantiate(m_ObjPool);
            enemy.SetActive(false);
            pooledObjects.Add(enemy);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; ++i)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        if (willGrow)
        {
            GameObject enemy = (GameObject)Instantiate(m_ObjPool);
            pooledObjects.Add(enemy);
            return enemy;
        }

        return null;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

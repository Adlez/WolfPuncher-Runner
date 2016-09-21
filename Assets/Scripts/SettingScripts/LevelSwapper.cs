using UnityEngine;
using System.Collections.Generic;

public class LevelSwapper : MonoBehaviour 
{
	public GameObject m_Player;
	public GameObject m_SpawnPos;
	string spawnName = "blank";
	int spawnIndex = 64;


	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Player")
		{
			m_Player.transform.position = m_SpawnPos.transform.position;
		}
	}
}
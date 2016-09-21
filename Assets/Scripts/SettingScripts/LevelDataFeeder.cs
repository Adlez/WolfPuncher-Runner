using UnityEngine;
using System.Collections;

public class LevelDataFeeder : MonoBehaviour 
{
	public GameObject ldf_WorldContainer;
	public GameObject ldf_ThisLevel;
	public GameObject ldf_ObstacleSpawnPos;
	Vector2 newOSP = new Vector2(0.1f, 0f);

	float _FinalYPos;

	bool _LevelEntered;

	void OnCollisionEnter2D(Collision2D collision)
	{
		//if (ldf_WorldContainer.GetComponent<LevelPlacer>().lp_CurLevel != ldf_ThisLevel)
		//{
			if (collision.collider.tag == "Player")
			{
				string curLevelName = collision.collider.name;
				ldf_WorldContainer.GetComponent<LevelPlacer>().lp_CurLevel = ldf_ThisLevel;
				ldf_WorldContainer.GetComponent<SpawnControllerScript>().ActivateSpawners();
				ldf_WorldContainer.GetComponent<LevelPlacer>().NewLevelEntered();
				if (!_LevelEntered)
				{
					_FinalYPos = ldf_ThisLevel.transform.position.y * -2.5f;
					//ldf_ThisLevel.transform.position = new Vector2(ldf_ThisLevel.transform.position.x, ldf_ThisLevel.transform.position.y * -2.5f);
					_LevelEntered = true;
				}
				//if (ldf_WorldContainer.GetComponent<LevelPlacer>().lp_PrevLevel != null)
				//{
				//	float newYPosForOldLevel = ldf_WorldContainer.GetComponent<LevelPlacer>().lp_PrevLevel.transform.position.y - 35f;
				//	ldf_WorldContainer.GetComponent<LevelPlacer>().lp_PrevLevel.transform.position = new Vector2(ldf_WorldContainer.GetComponent<LevelPlacer>().lp_PrevLevel.transform.position.x, newYPosForOldLevel);
				//}
			}
		//}
	}

	void Start () 
	{
		ldf_ThisLevel = this.gameObject.transform.parent.gameObject;
		ldf_ObstacleSpawnPos = ldf_ThisLevel.transform.FindChild("ObstclSpawnPos").gameObject;//.GetChild("").gameObject;
	}
	
	void Update () 
	{
		//newOSP.x += 0.01f;
		if (ldf_ObstacleSpawnPos != null)
		{
			//Vector3 oldPos = ldf_ObstacleSpawnPos.transform.position;// = ldf_ObstacleSpawnPos.transform.position + newOSP;
			Vector3 addPos = new Vector3(newOSP.x, 0, 0);
			ldf_ObstacleSpawnPos.transform.position += addPos;
			if (ldf_ThisLevel.transform.position.y <= _FinalYPos)
			{
				//ldf_ThisLevel.transform.position = new Vector2(ldf_ThisLevel.transform.position.x, ldf_ThisLevel.transform.position.y + 0.1f);
			}
		}
	}
}

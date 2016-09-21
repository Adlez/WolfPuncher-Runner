using UnityEngine;
using System.Collections.Generic;

public class LevelPlacer : MonoBehaviour 
{
	private GameObject lp_WorldContainer;
	public GameObject lp_NextLevel;
	public GameObject lp_CurLevel;
	public GameObject lp_TranLevel;
	public GameObject lp_CurLevelSection;
	public GameObject lp_PrevLevel;

	public List<GameObject> lp_ActiveLevels;
	public List<GameObject> lp_InactiveLevels;

	public Transform lp_RayStartPrefab;
	public Transform lp_RayEndPrefab;

	//public List<GameObject> lp_NumLevelSections = new List<GameObject>();

	public float lp_CurLevelSize;
	public float lp_YOffset = 1;
	private string _levelName;


	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Player")
		{
			GuideNextLevel(lp_NextLevel);
			string curLevelName = collision.collider.name;
			//lp_WorldContainer.GetComponent<SpawnControllerScript>().ActivateSpawners();
			lp_PrevLevel = lp_WorldContainer.GetComponent<SpawnControllerScript>().sc_CurLevel;
			lp_WorldContainer.GetComponent<SpawnControllerScript>().sc_CurLevel = lp_CurLevel;
		}
	}

	void Awake()
	{
		lp_WorldContainer = GameObject.FindGameObjectWithTag("WorldContainer");

		if (this.gameObject != lp_WorldContainer) //First make sure this isn't the WorldContainerObject
		{
			_levelName = lp_CurLevelSection.name.Remove(0, 8); //remove unnesccary characters in the name
			lp_NextLevel = GameObject.Find("Level" + _levelName); //use the shortened name to find the next level
			lp_CurLevel = this.transform.parent.gameObject; //find the current level the player is in
			this.transform.localScale = new Vector3(this.transform.localScale.x, 1f, this.transform.localScale.z); //Set the proper scale in order to override prefabs
			this.GetComponent<BoxCollider2D>().size = new Vector2(this.GetComponent<BoxCollider2D>().size.x, 0.8f);//Set the proper size in order to ovveride prefabs
			this.gameObject.layer = LayerMask.NameToLayer("GroundPlus");//Since we don't want the player flying through ground that should be solid we change the layer of these platforms

			this.GetComponent<BoxCollider2D>().enabled = false; //Disable the box collider of these platforms by default so the next level won't 
			//spawn unless the player actually touches the top after the raycast turns the collider back on

			if (this.GetComponent<GroundController>() == null)//Check to see if the script is already attached
			{
				GroundController grndControl = this.gameObject.AddComponent<GroundController>();
				//If the script is not attached then Attach it
			}

			GameObject RayStartPrefab = (GameObject)Resources.Load("PrefabsToLoad/RayLineStart", typeof(GameObject));
			GameObject RayEndPrefab = (GameObject)Resources.Load("PrefabsToLoad/RayLineEnd", typeof(GameObject));

			//create RayStart and End
			GameObject rayStart = Instantiate(RayStartPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
			rayStart.transform.parent = this.gameObject.transform;

			GameObject rayEnd = Instantiate(RayEndPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
			rayEnd.transform.parent = this.gameObject.transform;

			lp_RayStartPrefab = rayStart.gameObject.transform;
			lp_RayEndPrefab = rayEnd.gameObject.transform;

			this.GetComponent<GroundController>().grnd_BeginningOfRay = lp_RayStartPrefab;
			this.GetComponent<GroundController>().grnd_EndOfRay = lp_RayEndPrefab;

			this.GetComponent<GroundController>().DelayedStart(); //Now that we're sure ALL the right variables are in all the right places
			//we use the Groundcontroller's start function
		}
		else //This is the world container object
		{
			//lp_WorldContainer.GetComponent<SpawnControllerScript>().ActivateSpawners();
			//this.gameObject.GetComponent<SpawnControllerScript>().sc_CurLevel = lp_CurLevel;
			foreach(Transform child in transform)
			{
				lp_InactiveLevels.Add(child.gameObject); //Add ALL Levels to the inactive list
			}
			lp_InactiveLevels.Remove(this.transform.FindChild("Level-Karat").gameObject);//take the first level out of the inactive
			lp_ActiveLevels.Add(this.transform.FindChild("Level-Karat").gameObject); //and put it in the active
		}
		
	}

	void Update()
	{
		//lp_World Container Update
		if (this.gameObject == lp_WorldContainer)
		{
			//Active / Inactive Functionality goes here if its ever finished
		}
		else //individual platform update
		{
			lp_WorldContainer.GetComponent<LevelPlacer>().lp_CurLevel = lp_CurLevel;
			lp_WorldContainer.GetComponent<LevelPlacer>().lp_NextLevel = lp_NextLevel;
			lp_WorldContainer.GetComponent<LevelPlacer>().lp_CurLevelSection = lp_CurLevelSection;
		}
	}

	public void GuideNextLevel(GameObject nextLevel)
	{
		float sectionSize = lp_CurLevelSection.GetComponent<SpriteRenderer>().bounds.size.x; //get the width of the section

		lp_NextLevel = nextLevel; //tell this platform what the next level is
		lp_WorldContainer.GetComponent<LevelPlacer>().lp_NextLevel = lp_NextLevel; //tell the WorldContainer what the next level is
		lp_WorldContainer.GetComponent<LevelPlacer>().lp_TranLevel = lp_CurLevel; //Prepare the world for a Previous Level

		if (lp_WorldContainer.GetComponent<LevelPlacer>().lp_ActiveLevels.Contains(lp_NextLevel))//derrrr
		{

		}
		else//So if the Active levels list DOESN'T have this Next level in the list, 
		{
			lp_WorldContainer.GetComponent<LevelPlacer>().lp_ActiveLevels.Add(lp_NextLevel);//Add the next level to the Active list
			lp_WorldContainer.GetComponent<LevelPlacer>().lp_InactiveLevels.Remove(lp_NextLevel);//Remove it from the Inactive list
		}
		
		
		lp_YOffset = lp_CurLevelSection.transform.localScale.y; //in case a platform is scaled to a size we aren't expecting, compensate

		float newLevelPosX = lp_CurLevelSection.transform.position.x + (sectionSize * lp_CurLevelSection.transform.localScale.x);
		//use the width (with a variable in case its scale isn't 1) and current platforms xpos 
		//to determine the position the next level will need to be moved to
		float newLevelPosY = lp_CurLevelSection.transform.position.y;// *lp_YOffset;
		//use the current platform's y pos to determine where the enxt will go

		Vector2 nextLevelNewPos; //declare the new Vector we'll be using
		nextLevelNewPos = new Vector2(newLevelPosX, newLevelPosY); //assign the new vector the variables we got earlier from the current platform
		lp_NextLevel.transform.position = nextLevelNewPos; //give the new level the starting coordinates we determined above
	}

	public void NewLevelEntered()
	{
		lp_PrevLevel = lp_TranLevel;

	}
	
}


/* Active and Inactive functionality - currently not working
if (lp_PrevLevel != null)
			{
				if (lp_InactiveLevels.Contains(lp_PrevLevel))
				{}
				else
				{
					lp_InactiveLevels.Add(lp_PrevLevel);
					lp_ActiveLevels.Remove(lp_PrevLevel);
				}
			}
			for (int i = 0; i < lp_InactiveLevels.Count; ++i)
			{
				//lp_InactiveLevels[i].SetActive(false);
				lp_InactiveLevels[i].transform.position = new Vector2(0, -550);
			}
			for (int i = 0; i < lp_ActiveLevels.Count; ++i)
			{
				lp_ActiveLevels[i].transform.position = lp_ActiveLevels[i].transform.position;
				//lp_ActiveLevels[i].SetActive(true);
			}
			foreach (Transform child in transform)
			{
				if (child.gameObject != lp_CurLevel //If this is not the current level
					&& child.gameObject != lp_NextLevel //And it's not the next level
					&& child.gameObject != this.transform.FindChild("Level-Karat").gameObject) //AND it's not the first level
				{
					if(lp_InactiveLevels.Contains(child.gameObject)) { }//If the Inactive List doesn't already have it move on to the else
					else //This means the level is not in the Inactive list
					{
						lp_InactiveLevels.Add(child.gameObject); //Add the child to the inactive list

						if (lp_ActiveLevels.Contains(child.gameObject)) //Check if it's in the Active list (probably is)
						{
							lp_ActiveLevels.Remove(child.gameObject);//if it is, remove it. Because we just put it in the inactive list
						}
					}
				}
				if (lp_ActiveLevels.Contains(lp_NextLevel)) { }//in case the nextLevel wasn't added to the Active list, 
				else { lp_ActiveLevels.Add(lp_NextLevel); }// add it here
			}
*/
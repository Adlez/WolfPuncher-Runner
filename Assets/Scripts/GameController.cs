using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public string m_CurSetting;
    public List<string> m_Settings;

    public Sprite bg_Forest;
    public Sprite bg_Plateau;
    public Sprite bg_Karat;
    public Sprite bg_Road;
    private Sprite newBG;

    public Sprite grnd_Forest;
    public Sprite grnd_Plateau;
    public Sprite grnd_Karat;
    public Sprite grnd_Road;

    public GameObject[] m_Backgrounds = new GameObject[4];
    public GameObject[] m_Grounds = new GameObject[4];
    
    private bool m_GameOver;
    private bool m_Restart;
	public bool m_BGChange;

    public Text restartText;
    public Text gameOverText;
    public Text wolvesKilledText;

    public static int m_WolvesKilled = 0;

	// Use this for initialization
	void Start () 
	{
        m_GameOver = false;
        m_Restart = false;

        //restartText.text = "";
        //gameOverText.text = "";
        //wolvesKilledText.text = "0";

        m_Settings.Clear();
        m_Settings.Add("Forest");
        m_Settings.Add("Karat");
        m_Settings.Add("Plateau");
        m_Settings.Add("Plains");
        m_Settings.Add("MountainPass");
        m_Settings.Add("Ganical");
        m_Settings.Add("Mountains");
        m_Settings.Add("WideOpenPlains");
        m_Settings.Add("TownUnderTheBridge");
        m_Settings.Add("Bridge");
        m_Settings.Add("Dalez");
        m_Settings.Add("Ronald");
        m_Settings.Add("Grassland");
        m_Settings.Add("Vade");
        m_Settings.Add("Lakeside");
        m_Settings.Add("Amim");
        m_Settings.Add("Crater");
        m_Settings.Add("Sederal");

        m_Settings.Add("DesertRoad");
        m_Settings.Add("CraterRoad");
        m_Settings.Add("NorthEastRoad");
        m_Settings.Add("NorthWestRoad");
        m_Settings.Add("ShortRoad");
        m_Settings.Add("PhilipRoad");
        m_Settings.Add("MedicRoad");
        m_Settings.Add("UnderBridgeRoad");
        m_Settings.Add("ForestRoad");
        m_Settings.Add("FortressRoad");
	}

    public void SwapBackgrounds(string nameOfSetting)
    {
        if (nameOfSetting == "Forest")
        {
            for (int i = 0; i < m_Backgrounds.Length; ++i)
            {
                m_Backgrounds[i].GetComponent<SpriteRenderer>().sprite = bg_Forest;
            }
            for (int i = 0; i < m_Grounds.Length; ++i)
            {
                m_Grounds[i].GetComponent<SpriteRenderer>().sprite = grnd_Forest;
            }
        }
        else if (nameOfSetting == "Plateau")
        {
            for (int i = 0; i < m_Backgrounds.Length; ++i)
            {
                m_Backgrounds[i].GetComponent<SpriteRenderer>().sprite = bg_Plateau;
            }
            for (int i = 0; i < m_Grounds.Length; ++i)
            {
                m_Grounds[i].GetComponent<SpriteRenderer>().sprite = grnd_Plateau;
            }
        }
        else if (nameOfSetting == "Karat")
        {
            for (int i = 0; i < m_Backgrounds.Length; ++i)
            {
                m_Backgrounds[i].GetComponent<SpriteRenderer>().sprite = bg_Karat;
            }
            for (int i = 0; i < m_Grounds.Length; ++i)
            {
                m_Grounds[i].GetComponent<SpriteRenderer>().sprite = grnd_Karat;
            }
        }
        else if (nameOfSetting == "Road")
        {
            for (int i = 0; i < m_Backgrounds.Length; ++i)
            {
                m_Backgrounds[i].GetComponent<SpriteRenderer>().sprite = bg_Road;
            }
            for (int i = 0; i < m_Grounds.Length; ++i)
            {
                m_Grounds[i].GetComponent<SpriteRenderer>().sprite = grnd_Road;
            }
        }
    }

	// Update is called once per frame
	void Update () 
	{
        //wolvesKilledText.text = "" + m_WolvesKilled;

        if (m_Restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
	}

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        m_GameOver = true;
        restartText.text = "Press 'R' to restart.";
        m_Restart = true;
    }
}
/*
Old

public GameObject mSpawnObj;

	Vector3 spawnPos = new Vector3();
	Quaternion spawnRot = new Quaternion();

	void SpawnObj()
	{
		Instantiate(mSpawnObj, spawnPos, spawnRot);
	}
*/
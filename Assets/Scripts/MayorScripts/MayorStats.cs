using UnityEngine;
using System.Collections;

public class MayorStats : MonoBehaviour 
{
    public GameObject m_GameController;

	public Animator mIritAnimator;
	public Animator mSadAnimator;
	public Animator mBoredAnimator;

    public float m_Irritation;
    public float m_Boredom;
    public int m_Sadness;

    int MAXIRRITATION = 10;
    float MAXBOREDOM = 60.0f;
    int MAXSADNESS = 5;

    public float MINJUMPFORCE = 35000;
    public float MAXJUMPFORCE = 85000;

    public float tempMad;
    public int tempSad;

	// Use this for initialization
	void Start () 
	{
		mIritAnimator.SetFloat("Irritation", 0.0f);

        m_Irritation = 0;
        m_Boredom = 0.0f;
        m_Sadness = 0;

        MINJUMPFORCE = 35000;
        MAXJUMPFORCE = 85000;
	}
	
	// Update is called once per frame
	void Update () 
	{

        m_Irritation = mIritAnimator.GetFloat("Irritation");
        m_Boredom = mBoredAnimator.GetFloat("Boredom");
        m_Sadness = mSadAnimator.GetInteger("Sadness");

        if (m_Irritation >= MAXIRRITATION)
        {
            //end game
            m_GameController.GetComponent<GameController>().GameOver();
        }
        if (m_Boredom >= MAXBOREDOM)
        {
            //end game
            m_GameController.GetComponent<GameController>().GameOver();
        }
        if (m_Sadness >= MAXSADNESS)
        {
            //end game
            m_GameController.GetComponent<GameController>().GameOver();
        }
	}
}

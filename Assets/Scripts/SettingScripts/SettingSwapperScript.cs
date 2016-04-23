using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SettingSwapperScript : MonoBehaviour 
{
    public GameObject m_GameController;

    public Vector3 mVelocity;
    public Vector3 mRotation;
    public Vector3 mScaling;

    public float mRotSpeed;

    public float mJumpForce;
    public float mMaxSpeed;

    public Vector2 speed;

    public void ChangeSetting()//string newSetting)
    {
        m_GameController.GetComponent<GameController>().m_CurSetting = this.name + "";//newSetting;
        Debug.Log(m_GameController.GetComponent<GameController>().m_CurSetting);

        m_GameController.GetComponent<GameController>().SwapBackgrounds(this.name);
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = mVelocity.x * speed;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            //GameObject.FindObjectWithTag(SettingSwapper)
            //string colliderName = GetComponent<Collider>().name;
            ChangeSetting();//colliderName);
        }
    }
}

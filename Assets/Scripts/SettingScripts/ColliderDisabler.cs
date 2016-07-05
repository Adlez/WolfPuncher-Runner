using UnityEngine;
using System.Collections;

public class ColliderDisabler : MonoBehaviour 
{
    /*void onCollisionEnter(Collider2D objCollidedWith)
    {
        //eat me shit brick
        Debug.Log(objCollidedWith + "Shitstick");
        objCollidedWith.GetComponent<BoxCollider2D>().enabled = false;
    }*/

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
        if (collision.collider.tag == "Ground")
        {
            collision.collider.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}

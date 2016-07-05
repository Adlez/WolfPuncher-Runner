using UnityEngine;
using System.Collections;

public class Uniscroller : MonoBehaviour 
{
    public float scrollSpeed;
    private Transform groundTransform;

    private Vector3 newPosition;

    void Start()
    {
        newPosition = transform.position;
        groundTransform = Camera.main.transform;
    }

    void Update()
    {
        newPosition.x += Time.deltaTime * scrollSpeed;
        transform.position = newPosition;
    }
}

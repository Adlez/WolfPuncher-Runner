using UnityEngine;
using System.Collections;

public class GroundScroller : MonoBehaviour 
{
    public float scrollSpeed;
    private float groundWidth;
    
    private Transform groundTransform;

    private Vector3 newPosition;

    void Start()
    {
        newPosition = transform.position;
        groundTransform = Camera.main.transform;

        SpriteRenderer spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
        groundWidth = spriteRenderer.sprite.bounds.size.x;
    }

    void Update()
    {
        newPosition.x += Time.deltaTime * scrollSpeed;
        transform.position = newPosition;

        if ((transform.position.x + groundWidth/2.65) < groundTransform.position.x)
        {
            Vector3 newPos = transform.position;
            newPos.x += 1.0f * groundWidth;
            transform.position = newPos;
            newPosition = newPos;
        }

    }
}

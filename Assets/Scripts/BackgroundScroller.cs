using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    private Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = Mathf.Repeat(Time.time * scrollSpeed, 10);
        transform.position = startPos + Vector2.down * newY;
    }
}

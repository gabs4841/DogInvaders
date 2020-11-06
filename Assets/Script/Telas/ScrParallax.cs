using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrParallax : MonoBehaviour
{

    public float scrollSpeed = 1f, scrollOffset, newPos;
    public Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        newPos = Mathf.Repeat(Time.time * -scrollSpeed, scrollOffset);
        transform.position = startPos + Vector2.up * newPos;
    }
}

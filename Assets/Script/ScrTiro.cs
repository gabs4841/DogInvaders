using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrTiro : MonoBehaviour
{
    public SpriteRenderer render;
    public float velocidade = 100f;
    public bool soudobem = false;

    void Start()
    {
    }

    void Update()
    {
        if (!soudobem)
        {
            transform.Translate(new Vector2(0f, -velocidade * Time.deltaTime));
        }

        else
        {
            transform.Translate(new Vector2(0f, velocidade * Time.deltaTime));
        }
        if (!render.isVisible)
        {
            Destroy(gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrSomePonto : MonoBehaviour
{
    private SpriteRenderer imagem;
    private Color inicio;
    private Color fim;
    private float tempo;
    void Start()
    {
        imagem = GetComponent<SpriteRenderer>();
        inicio = imagem.color;
        fim = new Color(inicio.r, inicio.g, inicio.b, 00f);
        Invoke("suicidio", 0.5f);
    }

    void Update()
    {
        tempo += Time.deltaTime;
        imagem.material.color = Color.Lerp(inicio, fim, tempo);
    }

    void suicidio()
    {
        Destroy(gameObject);
    }
}

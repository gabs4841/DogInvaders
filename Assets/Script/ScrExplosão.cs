using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrExplosão : MonoBehaviour {

 //   private SpriteRenderer imagem;
 //   private Color inicio;
 //   private Color fim;
  //  private float tempo;

	void Start () {
        Invoke("memata", 1.5f);
        //imagem = GetComponent<SpriteRenderer>();
        //inicio = imagem.color;  
        //fim = new Color(inicio.r, inicio.g, inicio.b, 00f);
	}
	
	void Update () {
  //      tempo += Time.deltaTime;
  //      imagem.material.color = Color.Lerp(inicio, fim, tempo);
	}

    void memata()
    {
        Destroy(gameObject);
    }
}

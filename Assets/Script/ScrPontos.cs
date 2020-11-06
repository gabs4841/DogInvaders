using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrPontos : MonoBehaviour
{

    public float pontostotal = 0f, pontosrecorde = 0f;
    public Text txtpontos, txtrecorde;
    public bool toingame;
    
    void Start()
    {
        pontostotal = PlayerPrefs.GetFloat("pontos");

         if (PlayerPrefs.HasKey("recorde"))
        {
            pontosrecorde = PlayerPrefs.GetFloat("recorde");
        }
         txtrecorde.text = "Recorde: " + pontosrecorde;
         txtpontos.text = "Ultimos Pontos: " + pontostotal;
    }

    public void apagar() {
        PlayerPrefs.DeleteAll();
    }
}

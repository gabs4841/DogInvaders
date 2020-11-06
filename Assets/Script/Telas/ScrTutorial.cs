using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrTutorial : MonoBehaviour {

    public ScrHUD hud;
    public ScrPlayer player;
    public GameObject pausado;

    private void Awake()
    {
        pausado.SetActive(false);
        Invoke("pausa", 0.8f);
    }
    void Start () {
    }

    void Update()
    {

    }

    private void pausa()
    { 
        Time.timeScale = 0f;
    }
    public void despausado()
    {
        pausado.SetActive(true);
        Time.timeScale = 1f;
        player.possomover = true;
        hud.audios[0].Play();
        this.gameObject.SetActive(false);
    }
}

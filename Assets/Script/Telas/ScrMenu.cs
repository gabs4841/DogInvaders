using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScrMenu : MonoBehaviour {

    public GameObject recorde, easteregg, config;
    public float pontostotal = 0f, pontosrecorde = 0f, valorvolume = 0f;
    public int valordificuldade = 1;
    public Text txtpontos, txtrecorde;
    public Animator fade;
    public Image preto;
    private bool cliquei = false, cliqueieaster = false;
    public Slider volume;
    public AudioSource musica;
    public Dropdown dificuldade;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        volume.value = PlayerPrefs.GetFloat("volume"); 
        musica.volume = PlayerPrefs.GetFloat("volume");
        dificuldade.value = PlayerPrefs.GetInt("dificuldade");
    }
    void Start(){
    }
	
	void Update (){
        pontostotal = PlayerPrefs.GetFloat("pontos");
        pontosrecorde = PlayerPrefs.GetFloat("recorde");

        txtrecorde.text = ": " + pontosrecorde;
        txtpontos.text = ": " + pontostotal;

        if (cliquei)
        {
            if (preto.color.a == 1)
            {
                SceneManager.LoadScene("Gameplay");
            }
        }

        if (Input.touchCount >= 4)
        {
            easteregg.SetActive(true);
        }
    }

    public void Jogar()
    {
        cliquei = true;
        StartCoroutine("Fading");
    }

    public void Record()
    {
        recorde.SetActive(true);
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void Voltar()
    {
        recorde.SetActive(false);
    }

    public void apagar()
    {
        PlayerPrefs.DeleteAll();
    }

    public void EasterBack()
    {
        easteregg.SetActive(false);
        config.SetActive(false);
    }

    public void configuration()
    {
        config.SetActive(true);
    }

    public void configsalvar()
    {
        valorvolume = volume.value;
        PlayerPrefs.SetFloat("volume", valorvolume);
        valordificuldade = dificuldade.value;
        PlayerPrefs.SetInt("dificuldade", valordificuldade);
        config.SetActive(false);
    }

    IEnumerator Fading()
    {
        fade.SetBool("FadeOut", true);
        yield return new WaitUntil(() => preto.color.a == 1);
    }
}

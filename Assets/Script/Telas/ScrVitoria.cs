using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScrVitoria : MonoBehaviour {

    public float pontostotal = 0f, pontosrecorde = 0f;
    public Text txtpontos, txtrecorde;
    public Animator fade;
    public Image preto;
    private bool cliquei = false;
    public AudioSource musica;

    void Awake()
    {
        musica.volume = PlayerPrefs.GetFloat("volume");
        pontosrecorde = PlayerPrefs.GetFloat("recorde");
        pontostotal = PlayerPrefs.GetFloat("pontos");

        if (pontostotal > pontosrecorde)
        {
            pontosrecorde = pontostotal;
            PlayerPrefs.SetFloat("recorde", pontosrecorde);
        }
    }

	void Start () {
        txtpontos.text = ": " + pontostotal;
        txtrecorde.text = ": " + pontosrecorde;
	}
	
	void Update () {
        if (cliquei)
        {
            if (preto.color.a == 1)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    public void Voltar()
    {
        cliquei = true;
        StartCoroutine("Fading");
    }

    IEnumerator Fading()
    {
        fade.SetBool("FadeOut", true);
        yield return new WaitUntil(() => preto.color.a == 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScrHUD : MonoBehaviour
{
    public float combustivel = 100f, temporestante = 100f, pontostotal = 0f;
    public Text txtesq, txtdir, txtpontos;
    public Animator anim, fade;
    public AudioSource[] audios;
    public Image preto;
    public ScrPlayer player;
    public GameObject tempo, hpboss, boss, pontoinicial, pontofinal, menupause, tutorial;
    public int dificuldade;

    private void Awake()
    {
        dificuldade = PlayerPrefs.GetInt("dificuldade");
        audios[0].volume = PlayerPrefs.GetFloat("volume"); //Musica - Sonic
        audios[1].volume = PlayerPrefs.GetFloat("volume");  //Tiro - Laser
        audios[2].volume = PlayerPrefs.GetFloat("volume"); //Morte - Bolhas
        audios[3].volume = PlayerPrefs.GetFloat("volume"); //Item - Tuturu

        if (dificuldade == 0)
        {
            combustivel = 101;
        }
        else if (dificuldade == 1)
        {
            combustivel = 102;
        }
        else if (dificuldade == 2)
        {
            combustivel = 102;
        }
    }

    void Update()
    {
        if (temporestante > 0f)
        {
            temporestante -= Time.deltaTime;
        }
        if (combustivel > 0f && dificuldade == 0)
        {
            combustivel -= 1 * Time.deltaTime;
        }
        else if (combustivel > 0f && dificuldade == 1)
        {
            combustivel -= 2 * Time.deltaTime;
        }
        else if (combustivel > 0f && dificuldade == 2)
        {
            combustivel -= 3 * Time.deltaTime;
        }

        txtesq.text = Mathf.Round(combustivel) + "%";
        txtdir.text = Mathf.Round(temporestante) + "s";

        txtpontos.text = ": " + pontostotal;
        PlayerPrefs.SetFloat("pontos", pontostotal);

        if (Input.GetKeyDown(KeyCode.Escape) && !tutorial.activeInHierarchy)
        {
            if (menupause.activeInHierarchy)
            {
                despausado();
            }
            else
            {
                pausado();
            }
        }

        if (combustivel <= 0f)
        {
            Invoke("topreto", 1f);
            player.memata = true;


            if (preto.color.a == 1)
            {
                SceneManager.LoadScene("TelaDerrota");
            }
        }

        else if (temporestante <= 0f)
        {
            hpboss.SetActive(true);
            tempo.SetActive(false);
            pontoinicial.SetActive(true);
            pontofinal.SetActive(true);
            boss.SetActive(true);
        }
    }

    void topreto()
    {
        StartCoroutine("Fading");
    }

    public void pausado()
    {
        Time.timeScale = 0f;
        menupause.SetActive(true);
    }

    public void despausado()
    {
        menupause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    IEnumerator Fading()
    {
        fade.SetBool("FadeOut", true);
        yield return new WaitUntil(() => preto.color.a == 1);
    }
}

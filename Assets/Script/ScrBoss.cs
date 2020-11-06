using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScrBoss : MonoBehaviour
{

    public GameObject Boss, tiro, umponto, doisponto, tresponto, quatroponto, seisponto;
    public Transform[] paraondeir;
    public Transform top, mid, adc, jg, supp, gg, bot;
    public float Velocidade = 0f, tempo;
    public int contador = 0;
    public bool especial = false, golpe = true;
    public Slider vida;
    public ScrHUD hud;
    public Animator fade;
    public Image preto;
    public ScrPlayer jogador;
    public int dificuldade;

    void Awake()
    {
        dificuldade = PlayerPrefs.GetInt("dificuldade");
        hud.pontostotal = PlayerPrefs.GetFloat("pontos");
        hud.combustivel = 100f;
    }
    void Start()
    {
    }

    void Update()
    {
        tempo += Time.deltaTime;

        if (tempo >= 0.4)
        {
            if (!especial)
            {
                Instantiate(tiro, top.position, Quaternion.identity);
                Instantiate(tiro, mid.position, Quaternion.identity);
                Instantiate(tiro, adc.position, Quaternion.identity);
                Instantiate(tiro, supp.position, Quaternion.identity);
                tempo = 0f;
            }
            else if (especial)
            {
                tempo = 0f;
                Instantiate(tiro, gg.position, Quaternion.identity);
                Instantiate(tiro, bot.position, Quaternion.identity);
                Instantiate(tiro, jg.position, Quaternion.identity);
                especial = false;
                golpe = false;
            }

        }

        Boss.transform.position = Vector2.MoveTowards(Boss.transform.position, paraondeir[contador].position, Velocidade * Time.deltaTime);

        if (Boss.transform.position == paraondeir[contador].position)
        {
           contador++;
            if (contador == 2)
            {
                contador = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D quem)
    {
        if (quem.gameObject.tag == "gato")
        {
            vida.value -= 0.010f;
            if (dificuldade == 0)
            {
                if (!jogador.dobro)
                {
                    hud.pontostotal += 10f;
                    Instantiate(umponto, this.transform.position, Quaternion.identity);
                }
                else
                {
                    hud.pontostotal += 20f;
                    Instantiate(doisponto, this.transform.position, Quaternion.identity);
                }

            }
            else if (dificuldade == 1)
            {
                if (!jogador.dobro)
                {
                    hud.pontostotal += 20f;
                    Instantiate(doisponto, this.transform.position, Quaternion.identity);
                }
                else
                {
                    hud.pontostotal += 40f;
                    Instantiate(quatroponto, this.transform.position, Quaternion.identity);
                }
            }
          
            else if (dificuldade == 2)
            {
                if (!jogador.dobro)
                {
                    hud.pontostotal += 30f;
                    Instantiate(tresponto, this.transform.position, Quaternion.identity);
                }
                else
                {
                    hud.pontostotal += 60f;
                    Instantiate(seisponto, this.transform.position, Quaternion.identity);
                }
            }

            if (golpe)
            {
                if (vida.value <= 0.2)
                {
                    especial = true;
                }
            }
            if (vida.value <= 0.1)
            {
                SceneManager.LoadScene("TelaVitória");
            }
            Destroy(quem.gameObject);
        }
    }

    IEnumerator Fading()
    {
        fade.SetBool("FadeOut", true);
        yield return new WaitUntil(() => preto.color.a == 1);
    }
}

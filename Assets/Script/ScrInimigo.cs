using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrInimigo : MonoBehaviour {

    public ScrSpawner spawn;
    public float velocidade, tempo, vida = 8;
    public string NomeCaminho;
    public GameObject explosao, tiro, umponto, doisponto, tresponto,quatroponto,seisponto;
    private SpriteRenderer srender;
    public Transform mid,top;
    public bool soudogao = false, naoatiro = false;
    public ScrHUD hud;
    public ScrPlayer jogador;
    public int dificuldade;

    void Awake()
    {
        dificuldade = PlayerPrefs.GetInt("dificuldade");
        srender = GetComponent<SpriteRenderer>();
        transform.FollowPath(NomeCaminho, velocidade, Mr1.FollowType.Loop);
    }

    void Start () {
	}

    void Update() {
        if (srender.isVisible)
        {
            tempo += Time.deltaTime;
        }

        if (soudogao && tempo >= 1)
        {
            Instantiate(tiro, top.position, Quaternion.identity);
            Instantiate(tiro, mid.position, Quaternion.identity);
            tempo = 0f;
        }

        else if (!naoatiro && tempo >= 1.2)
        {
            Instantiate(tiro, mid.position, Quaternion.identity);
            tempo = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D quem)
    {
        if (quem.gameObject.tag == "gato")
        {
            vida -= 1f;
            if (dificuldade == 0)
            {
                if (jogador.dobro)
                {
                    hud.pontostotal += 20f;
                    Instantiate(doisponto, this.transform.position, Quaternion.identity);
                }
                else
                {
                    hud.pontostotal += 10f;
                    Instantiate(umponto, this.transform.position, Quaternion.identity);
                }
                Destroy(quem.gameObject);
            }
            else if (dificuldade == 1)
            {
                if (jogador.dobro)
                {
                    hud.pontostotal += 40f;
                    Instantiate(quatroponto, this.transform.position, Quaternion.identity);
                }
                else
                {
                    hud.pontostotal += 20f;
                    Instantiate(doisponto, this.transform.position, Quaternion.identity);
                }
                Destroy(quem.gameObject);
            }
            else if(dificuldade == 2)
            {
                if (jogador.dobro)
                {
                    hud.pontostotal += 60f;
                    Instantiate(seisponto, this.transform.position, Quaternion.identity);
                }
                else
                {
                    hud.pontostotal += 30f;
                    Instantiate(tresponto, this.transform.position, Quaternion.identity);
                }
                Destroy(quem.gameObject);
            }
            if (vida == 0)
            {
                Instantiate(explosao, this.transform.position, Quaternion.identity);
                hud.audios[3].Play();
                Destroy(gameObject);
                spawn.inimigosdead += 1;
            }
        }
    }
}

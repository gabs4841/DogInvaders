using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrPlayer : MonoBehaviour
{
    public ScrHUD hud;
    public float velocidade = 2f, deslocamentoVertical = 1f, tempo, forcapulo;
    public GameObject tiro, explosao;
    public bool especial, dobro = false, possomover, memata = false;
    private Rigidbody2D corpo;
    public Transform top, mid, bot;
    public int dificuldade;

    private void Awake()
    {
        dificuldade = PlayerPrefs.GetInt("dificuldade");
    }
    private void Start()
    {
        corpo = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        tempo += Time.deltaTime;

        if (memata)
        {
            Instantiate(explosao, this.transform.position, Quaternion.identity);
            hud.audios[3].Play();
            Destroy(gameObject);
        }

        #region Tipos De Tiro
        if (Time.timeScale == 1 && possomover)
        {
            if (tempo >= 0.3)
            {

                if (!especial)
                {
                    hud.audios[1].Play();
                    Instantiate(tiro, mid.position, Quaternion.identity);
                    tempo = 0f;
                }
                else if (especial)
                {
                    hud.audios[1].Play();
                    Instantiate(tiro, top.position, Quaternion.identity);
                    Instantiate(tiro, mid.position, Quaternion.identity);
                    Instantiate(tiro, bot.position, Quaternion.identity);
                    tempo = 0f;
                }

            }
        }
        #endregion
        #region Movimentação
        // if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        if (Time.timeScale == 1 && possomover)
        {
            {
                Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                target.y += deslocamentoVertical;

                float x = Mathf.Clamp(target.x, -2.28f, 2.28f);
                float y = Mathf.Clamp(target.y, -4.5f, 4.5f);

                target = new Vector2(x, y);

                transform.Translate(Vector2.MoveTowards(transform.position, target, velocidade * Time.deltaTime) - new Vector2(transform.position.x, transform.position.y));
            }
        }
        #endregion
    }

    void OnTriggerEnter2D(Collider2D quem)
    {
        if (quem.gameObject.tag == "combustivel")
        {
            hud.combustivel = 100f;
            Destroy(quem.gameObject);
        }

        if (quem.gameObject.tag == "fakecombustivel")
        {
            if (dificuldade == 0)
            {
                hud.anim.SetBool("pisca", true);
                Invoke("paradepiscar", 1f);
                if (hud.combustivel >= 20f)
                {
                    hud.combustivel -= 20f;
                }
                else
                {
                    hud.combustivel = 0f;
                }
                Destroy(quem.gameObject);
            }
            else if (dificuldade == 1)
            {
                hud.anim.SetBool("pisca", true);
                Invoke("paradepiscar", 1f);
                if (hud.combustivel >= 30f)
                {
                    hud.combustivel -= 30f;
                }
                else
                {
                    hud.combustivel = 0f;
                }
                Destroy(quem.gameObject);
            }
            else if (dificuldade == 2)
            {
                hud.anim.SetBool("pisca", true);
                Invoke("paradepiscar", 1f);
                if (hud.combustivel >= 40f)
                {
                    hud.combustivel -= 40f;
                }
                else
                {
                    hud.combustivel = 0f;
                }
                Destroy(quem.gameObject);
            }
        }

        if (quem.gameObject.tag == "especial")
        {
            if (especial)
            {
                hud.audios[2].Play();
                CancelInvoke("desliga");
                Invoke("desliga", 5f);
                Destroy(quem.gameObject);
            }
            else
            {
                hud.audios[2].Play();
                especial = true;
                Invoke("desliga", 5f);
                Destroy(quem.gameObject);
            }
        }

        if (quem.gameObject.tag == "pontosx2")
        {
            if (dobro)
            {
                hud.audios[2].Play();
                CancelInvoke("desligadobro");
                Invoke("desligadobro", 5f);
                Destroy(quem.gameObject);
            }
            else
            {
                hud.audios[2].Play();
                dobro = true;
                Invoke("desligadobro", 5f);
                Destroy(quem.gameObject);
            }
        }

        if (quem.gameObject.tag == "tiro")
        {
            if(dificuldade == 0)
            {
                if (hud.combustivel >= 20f)
                {
                    hud.combustivel -= 20f;
                }
                else
                {
                    hud.combustivel = 0f;
                }
                Destroy(quem.gameObject);
            }
            else if(dificuldade == 1)
            {
                if (hud.combustivel >= 30f)
                {
                    hud.combustivel -= 30f;
                }
                else
                {
                    hud.combustivel = 0f;
                }
                Destroy(quem.gameObject);
            }
            else if (dificuldade == 2)
            {
                if (hud.combustivel >= 40f)
                {
                    hud.combustivel -= 40f;
                }
                else
                {
                    hud.combustivel = 0f;
                }
                Destroy(quem.gameObject);
            }
        }

        if (quem.gameObject.tag == "volta")
        {
            corpo.AddForce(new Vector2(0f, -forcapulo), ForceMode2D.Force);
        }
    }

    void OnTriggerExit2D(Collider2D quem)
    {
    }

    void desliga(){
        especial = false;
}

    void desligadobro()
    {
        dobro = false;
    }


    void paradepiscar()
    {
        hud.anim.SetBool("pisca", false);
    }
}   
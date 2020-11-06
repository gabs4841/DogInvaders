using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScrLoading : MonoBehaviour
{

    public GameObject telaCarregamento;
    public Slider barraProgresso;
    public Text lblProgresso, lblrandom;
    public string[] conteudo;
    public int batata;

    private void Awake()
    {
        batata = Random.Range(0, 6);
    }

    private void Start()
    {
        lblrandom.text = conteudo[batata] + "";
    }
    public void CarregarCena(int indiceCena)
    {
        StartCoroutine(carregando(indiceCena));
    }

    IEnumerator carregando(int indiceCena)
    {
        AsyncOperation operacao = SceneManager.LoadSceneAsync(indiceCena);

        telaCarregamento.SetActive(true);

        while (!operacao.isDone)
        {
            float progresso = Mathf.Round(operacao.progress);
            if (progresso == .9f) { progresso = 1f; }
            barraProgresso.value = progresso;
            lblProgresso.text = (progresso * 100f) + "%";
            yield return null;
        }

    }


}
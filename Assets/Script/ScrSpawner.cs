using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrSpawner : MonoBehaviour {
    
    public GameObject[] drops,wave;
    public float tempo,jogados;
    public int item, inimigosdead;

	void Start () {
        tempo = 4f;
        inimigosdead = 0;
    }
	
	void Update () {
        tempo += Time.deltaTime;

        if (tempo >= 5)
        {
            item = (int)Random.Range(0f, 3f);
            Vector3 position = new Vector3(Random.Range(-2.5f, 2.5f), 20f, 0f);
            Instantiate(drops[item], position, Quaternion.identity);
            jogados++;
            tempo = 0f;
        }

        if (jogados == 4)
        {
            Vector3 position = new Vector3(Random.Range(-2.5f, 2.5f), 20f, 0f);
            Instantiate(drops[3], position, Quaternion.identity);
            jogados = 0;
        }

        if (inimigosdead == 4)
        {
            Invoke("wave2", 2f);
            Invoke("wave3", 10f);
            Invoke("wave4", 16.5f);
            Invoke("wave5", 29f);
        }
    }

    void wave2()
    {
        wave[0].SetActive(true);
    }

    void wave3()
    {
        wave[1].SetActive(true);
    }

    void wave4()
    {
        wave[2].SetActive(true);
    }

    void wave5()
    {
        wave[3].SetActive(true);
    }

}

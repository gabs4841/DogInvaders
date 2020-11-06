using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrPoeira: MonoBehaviour
{
    public float velocidadeR = 3f, QRotacao = 60f;
    int direcaoR = 0;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 20f);
    }

    void Update()
    {
        direcaoR = 1;

        Quaternion rotacao = transform.rotation;
        float z = rotacao.eulerAngles.z;
        z += direcaoR * velocidadeR * QRotacao * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, z);

    }

}

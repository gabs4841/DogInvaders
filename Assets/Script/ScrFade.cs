using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrFade : MonoBehaviour {

    public Animator fade;
    public Image preto;
   
	void Start () {
   }
	
	void Update () {
		
	}

    IEnumerator Fading()
    {
        fade.SetBool("FadeOut", true);
        yield return new WaitUntil(() => preto.color.a == 1);
        fade.SetBool("FadeOut", false);
    }
}

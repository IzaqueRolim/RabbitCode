using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlocoLocal : MonoBehaviour {



	Image x;
	public static bool tocando;
	public Sprite Brilho;
	public Sprite Padrao;


	void OnTriggerEnter2D(Collider2D obj){

		if (gameObject.tag == "ativo") {
			x = GetComponent<Image> ();
			x.sprite = Brilho;
			tocando = true;
		}
	}


	void OnTriggerExit2D(){
		if (gameObject.tag == "ativo") {
			if (Bloco1.Encaixado == false) {
				x.sprite = Padrao;
				tocando = false;
			}
		}
	}





	// Use this for initialization
	void Start () {
		tocando = false;
	}
}

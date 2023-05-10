using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estrela : MonoBehaviour {

	Animator anim;
	Collider2D ColisorObjeto;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		ColisorObjeto = GetComponent<Collider2D> ();
	}


	void OnTriggerEnter2D(Collider2D obj){
		if (obj.tag == "Player") {
			anim.SetBool ("Estrela",true);
			Fase1.EstrelasNum++;
			Destroy (ColisorObjeto);
			Destroy (gameObject, 0.6f);
		}

	}
}
